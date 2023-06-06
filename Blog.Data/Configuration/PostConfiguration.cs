using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Configuration
{
    public class PostConfiguration : EntityTypeConfiguration<Entities.Post>
    {
        public PostConfiguration()
        {
            Property(p => p.Title).IsRequired().HasMaxLength(50);
        }
    }
}
