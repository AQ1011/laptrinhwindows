using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mindmapdraw.Models
{
    [Table("MindMapClass")]
    public class MindMapClass
    {
        public MindMapClass()
        {
            listTopics = new HashSet<TopicClass>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string name { get; set; }
        public ICollection<TopicClass> listTopics { get; set; } 
    }
}
