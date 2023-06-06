using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Post: EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "El título debe ser menor de 250 caracteres", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
