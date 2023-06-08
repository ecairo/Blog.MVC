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

        public bool AceptarTerminos { get; set; }
    }
}