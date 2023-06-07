using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogEntities>
    {
        protected override void Seed(BlogEntities blogEntities)
        {
            // ... Inicializar DB con datos de pruebas

            GetAuthors().ForEach(a => blogEntities.Authors.AddOrUpdate(a));

            blogEntities.Commit();
        }

        public static List<Entities.Author> GetAuthors()
        {
            return new List<Entities.Author>()
            {
                new Entities.Author()
                {
                    Name = "George RR Martin",
                    Email = "published@got.com",
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Entities.Author()
                {
                    Name = "Tolkien RR",
                    Email = "published@lotr.com",
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
            };
        }
    }
}
