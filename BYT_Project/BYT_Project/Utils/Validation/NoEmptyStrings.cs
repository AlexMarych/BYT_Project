using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Utils.Validation
{
    public class NoEmptyStrings : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<string> list && list.Any(string.IsNullOrWhiteSpace))
                return new ValidationResult("The list contains empty strings.");

            return ValidationResult.Success;
        }
    }
}
