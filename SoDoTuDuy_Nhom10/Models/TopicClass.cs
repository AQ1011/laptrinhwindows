using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mindmapdraw.Models
{
    [Table("TopicClass")]
    public class TopicClass
    {
        public TopicClass()
        {
            this.listTopics = new HashSet<TopicClass>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int shape { get; set; }

        public ICollection<TopicClass> listTopics { get; set; }
        public MindMapClass mindMap { get; set; }
    }
}
