using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class Author: EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre debe ser menor de 50 caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Debe ser un email válido")]
        public string Email { get; set; }

        public string GravatarUrl { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
