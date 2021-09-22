using System.Collections.Generic;

namespace CodeCoverageWorkshop.Logic
{
    public class ValidationResult
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public void AddValidationResult(string val)
        {
            ErrorMessages.Add(val);
        }
    }
}
