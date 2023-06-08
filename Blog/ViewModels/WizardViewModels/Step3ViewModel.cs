using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.ViewModels.WizardViewModels
{
    public class Step3ViewModel
    {
        [Required(ErrorMessage = "El número de cuenta es requerido")]
        public string NumeroCuenta { get; set; }

        [Required(ErrorMessage = "Debes aceptar los términos y condiciones")]
        [Display(Name = "Acepto los términos y condiciones")]
        public bool AceptarTerminos { get; set; }
    }
}