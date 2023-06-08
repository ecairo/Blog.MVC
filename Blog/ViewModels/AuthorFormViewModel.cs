using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class AuthorFormViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "El nombre debe ser menor de 50 caracteres", MinimumLength = 3)]
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string GravatarUrl { get; set; }
    }
}