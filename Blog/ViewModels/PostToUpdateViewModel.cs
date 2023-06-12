using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class PostToUpdateViewModel
    {
        // DTO = Data Transfer Object

        [Required]
        [StringLength(250, ErrorMessage = "El título debe ser menor de 250 caracteres", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}