using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibros.Validations
{
    public class FechaMinimaAtributte : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var fechaMinima = new DateTime(1950, 1, 1);

            if (DateTime.Parse(value.ToString()) < fechaMinima) {

                return new ValidationResult("La fecha minima es 01-01-1950");
            }

            return ValidationResult.Success;
        }

    }
}
