using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        }
    }
}
