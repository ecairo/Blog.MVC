using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class AuthorDetailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string GravatarUrl { get; set; }

        public int Posts { get; set; }

        public int Comments { get; set; }
    }
}