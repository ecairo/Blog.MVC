using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class PostToCreationViewModel
    {
        [Required]
        [StringLength(250, ErrorMessage = "El título debe ser menor de 250 caracteres", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}