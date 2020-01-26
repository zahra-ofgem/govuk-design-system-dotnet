using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GovUkDesignSystem.Validators
{
    public class GovUkIntegerValidator2 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return new ValidationResult("qq:DCC Failed validation 2");
        }
    }
}
