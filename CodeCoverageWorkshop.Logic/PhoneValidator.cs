using System.Linq;

namespace CodeCoverageWorkshop.Logic
{
    public class PhoneValidator : IPhoneValidator
    {
        public ValidationResult Validate(string input)
        {
            var result = new ValidationResult();
            if (string.IsNullOrEmpty(input))
            {
                result.AddValidationResult("Nie podano numeru telefonu.");
            }
            else
            {
                var numericPhoneNumber = new string(input.Where(char.IsDigit).ToArray());
                if (numericPhoneNumber.Length != 9)
                {
                    result.AddValidationResult("Numer telefonu ma mieć 9 cyfr.");
                }
            }

            return result;
        }
    }

    public interface IPhoneValidator
    {
        ValidationResult Validate(string number);
    }
}
