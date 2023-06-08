using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.ViewModels.WizardViewModels
{
    public class Step2ViewModel
    {
        [Required(ErrorMessage = "El DNI es requerido")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }
    }
}