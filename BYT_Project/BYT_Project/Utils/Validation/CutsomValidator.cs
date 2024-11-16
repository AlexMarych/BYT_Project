using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Utils.Validation
{
    public class CutsomValidator
    {
        public static void Validate<T>(T obj)
        {
            var context = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, validationResults, true);

            if (!isValid)
            {
                var errorMessages = string.Join("; ", validationResults.Select(vr => vr.ErrorMessage));
                throw new ValidationException($"Validation failed: {errorMessages}");
            }
        }
    }
}