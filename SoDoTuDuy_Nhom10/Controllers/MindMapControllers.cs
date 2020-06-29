using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mindmapdraw.Models;

namespace mindmapdraw.Controllers
{
    public class MindMapControllers
    {
        public static int GetIDfromDB()
        {
            try
            {
                using (var _context = new DBTopicContext())
                {
                    var ids = (from t in _context.dbMM
                               select t.ID).Max() + 1;
                    return ids;
                }
            }
            catch
            {
                return 1;
            }
        }
        public static bool AddMindMap(MindMapClass mindmap)
        {
                using (var _context = new DBTopicContext())
                {
                    _context.dbMM.Add(mindmap);
                    _context.SaveChanges();
                    return true;
                }
        }
        public static bool UpdateMindMap(MindMapClass mindmap)
        {
            using (var _context = new DBTopicContext())
            {
                _context.dbMM.AddOrUpdate(mindmap);
                _context.SaveChanges();
                return true;
            }
        }
        public static void RemoveMindMap(int taskID)
        {
            using (var _context = new DBTopicContext())
            {
                var task = (from t in _context.dbMM
                            where t.ID == taskID
                            select t).FirstOrDefault();
                foreach (TopicClass topic in task.listTopics)
                    TopicControllers.RemoveTask(topic.ID);
                _context.dbMM.Remove(task);
                _context.SaveChanges();
            }
        }
        public static MindMapClass LoadMindMap(int ID)
        {
            using (var _context = new DBTopicContext())
            {
                var mm = _context.dbMM.Include("listTopics").Where(x => x.ID == ID).FirstOrDefault();
                return mm;
            }
        }
        public static List<MindMapClass> LoadAllMindMap()
        {
            using (var _context = new DBTopicContext())
            {
                var mm = (from t in _context.dbMM.Include("listTopics")
                          select t).ToList();
                return mm;
            }
        }
    }
}
