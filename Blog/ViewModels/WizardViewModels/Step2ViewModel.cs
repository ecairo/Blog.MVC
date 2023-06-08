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
        [RegularExpression(@"^\d{8}[a-zA-Z]$", ErrorMessage = "El DNI no es válido")]
        public string DNI { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La provincia es requerida")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El municipio es requerido")]
        [ProvinceValidator] // Aplicando el Validator que hemos hecho
        public string Municipio { get; set; }
    }

    public class ProvinceValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formulario = (Step2ViewModel)validationContext.ObjectInstance;

            // Validar la relación entre municipio y provincia
            if (formulario.Municipio == "MunicipioEjemplo" && formulario.Provincia != "ProvinciaEjemplo")
            {
                return new ValidationResult("El municipio seleccionado no corresponde a la provincia seleccionada.");
            }

            return ValidationResult.Success;
        }
    }
}