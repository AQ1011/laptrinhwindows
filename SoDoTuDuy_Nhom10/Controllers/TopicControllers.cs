using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using mindmapdraw.Models;

namespace mindmapdraw.Controllers
{
    public class TopicControllers
    {
        public static int GetIDfromDB()
        {
            try
            {
                using (var _context = new DBTopicContext())
                {
                    var ids = (from t in _context.dbTopic
                               select t.ID).Max() + 1;
                    return ids;
                }
            }
            catch
            {
                return 1;
            }
        }
        public static bool  UpdateTopic(TopicClass topic)
        {
            using (var _context = new DBTopicContext())
            {
                var a = (from u in _context.dbTopic.Include("mindMap")
                            where u.ID == topic.ID
                            select u).Single();
                foreach (var t in topic.listTopics)
                {
                    var to = (from u in _context.dbTopic.Include("listTopics")
                              where u.ID == t.ID
                              select u).Single();
                    if (!to.listTopics.Contains(a))
                        to.listTopics.Add(a);
                    else
                        continue;

                }
                a.Text = topic.Text;
                a.Width = topic.Width;
                a.Height = topic.Height;
                a.X = topic.X;
                a.Y = topic.Y;
                if (a.mindMap == null)
                    a.mindMap = (from u in _context.dbMM
                                 where u.ID == topic.mindMap.ID
                                 select u).Single();
                _context.SaveChanges();
                return true;
            }
        }
        public static bool DeleteTopicConnection(TopicClass first, TopicClass second)
        {
            using (var _context = new DBTopicContext())
            {
                var a = (from u in _context.dbTopic
                         where u.ID == first.ID
                         select u).Single();
                var b = (from u in _context.dbTopic
                                where u.ID == second.ID
                                select u).Single();
                a.listTopics.Remove(b);
                _context.dbTopic.AddOrUpdate(a);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool AddTopic(TopicClass topic)
        {
            using (var _context = new DBTopicContext())
            {
                _context.dbTopic.Add(topic);
                _context.SaveChanges();

                return true;
            }
        }

        public static TopicClass GetTopic(int ID)
        {
            using (var _context = new DBTopicContext())
            {
                var topic = _context.dbTopic.Include("listTopics").Where(t => t.ID == ID).FirstOrDefault();
                return topic;
            }
        }
        public static List<TopicClass> GetAllTopic()
        {
            using (var _context = new DBTopicContext())
            {
                var topics = (from t in _context.dbTopic.AsEnumerable()
                             select new
                             {
                                 id = t.ID,
                                 color= t.Color,
                                 x = t.X,
                                 y= t.Y,
                                 width = t.Width,
                                 height = t.Height,
                                 text = t.Text,
                                 lt = t.listTopics
                             })
                             .Select(x => new TopicClass
                             {
                                 ID = x.id,
                                 Color = x.color,
                                 X = x.x,
                                 Y = x.y,
                                 Width = x.width,
                                 Height = x.height,
                                 Text = x.text,
                                 listTopics = x.lt
                             });
                return topics.ToList();
            }
        }
        public static void RemoveTask(int taskID)
        {
            using (var _context = new DBTopicContext())
            {
                var task = (from t in _context.dbTopic
                            where t.ID == taskID
                            select t).FirstOrDefault();
                foreach(TopicClass topic in task.listTopics)
                {
                    topic.listTopics.Remove(task);
                }
                task.listTopics.Clear();
                _context.dbTopic.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
