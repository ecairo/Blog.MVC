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
        public static List<Entities.Author> GetAuthors()
        {
            return new List<Entities.Author>()
            {
                new Entities.Author()
                {
                    Name = "George",
                    FirstName = "RR",
                    LastName = "Martin",
                    Email = "published@got.com",
                    Id = Guid.Parse("d64d0d6e-ba3c-47f1-a9f7-d573d5999bcd"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Entities.Author()
                {
                    Name = "Tolkien",
                    FirstName = "RR",
                    Email = "published@lotr.com",
                    Id = Guid.Parse("d7f222ad-84da-43f9-b05d-daa2e78f6ee8"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
            };
        }
    }
}
