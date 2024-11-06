using System.ComponentModel.DataAnnotations;

namespace BYT_Project
{
    public class CutsomValidator
    {
        public static void Validate<T>(T obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

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