using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace mindmapdraw.Models
{
    public class DBTopicContext : DbContext
    {
        public DbSet<MindMapClass> dbMM { get; set; }
        public DbSet<TopicClass> dbTopic { get; set; }
        public DBTopicContext() : base("name=DBEntityTopic")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TopicClass>().HasMany(m => m.listTopics).WithMany().Map(m =>
                {
                    m.MapLeftKey("firstID");
                    m.MapRightKey("secondId");
                    m.ToTable("Connected");
                }
            );
        }
    }
}
