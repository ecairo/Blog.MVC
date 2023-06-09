using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Blog.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }

        public virtual Author Author { get; set; }
    }
}
