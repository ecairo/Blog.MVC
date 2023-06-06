using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class Comment : EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
