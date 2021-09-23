using System.Collections.Generic;
using System.Linq;

namespace CodeCoverageWorkshop.Logic
{
    public class ValidationResult
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();
        public bool IsValid => ErrorMessages.Any() == false;

        public void AddValidationResult(string val)
        {
            ErrorMessages.Add(val);
        }
    }
}
