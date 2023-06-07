using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}