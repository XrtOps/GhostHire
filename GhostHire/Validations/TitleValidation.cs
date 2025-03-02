using System.ComponentModel.DataAnnotations;

namespace GhostHire.Validations
{
    public class TitleValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Title is Required");
            }
            return ValidationResult.Success;
        }
    }
}
