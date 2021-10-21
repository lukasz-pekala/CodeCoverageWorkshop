using CodeCoverageWorkshop.Logic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CodeCoverageWorkshop.Logic
{
    public class LoginValidator : ILoginValidator
    {
        private readonly IUserService _userService;
        private readonly IGlossaryService _glossaryService;

        public LoginValidator(IUserService userService, IGlossaryService glossaryService)
        {
            _userService = userService;
            _glossaryService = glossaryService;
        }

        public void Validate(string login, string password)
        {
            var validationMessages = new List<string>(); // #100%CoverageMyth: unused code - intentionally here

            if (_userService.UserExists(login))
                throw new ValidationException("Podany login jest już zajęty");
            if (string.Equals(login, password, StringComparison.InvariantCultureIgnoreCase))
                throw new ValidationException("Login nie może być taki sam jak hasło do systemu");

            var forbiddenLogins = _glossaryService.GetElements(GlossaryConsts.ForbiddenLogins);

            if (forbiddenLogins.Any(x => string.Equals(x, login, StringComparison.InvariantCultureIgnoreCase)))
                throw new ValidationException("Login nie może zawierać słowa uważanego za niecenzuralne");
        }
    }

    public interface ILoginValidator
    {
        void Validate(string login, string password);
    }
}
