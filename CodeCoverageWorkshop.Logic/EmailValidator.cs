using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeCoverageWorkshop.Logic
{
    public class EmailValidator : IEmailValidator
    {
        public ValidationResult Validate(string input)
        {
            var regex = new Regex(
                "^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9]+)*\\.([a-zA-Z]{2,63})$");
            if (regex.IsMatch(input) == false)
                return new ValidationResult() {ErrorMessages = new List<string>() { "Adres e-mail jest niepoprawny." } };

            return new ValidationResult();
        }
    }

    public interface IEmailValidator
    {
        ValidationResult Validate(string input);
    }
}
