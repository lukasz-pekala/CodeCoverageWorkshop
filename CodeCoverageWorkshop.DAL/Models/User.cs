using System;
using System.Collections.Generic;

namespace CodeCoverageWorkshop.DAL.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime AccountActivationDate { get; set; }

        // WARN: Never use plain passwords in production! This is only for simplification
        public string Password { get; set; }

        //public List<Role> Roles { get; set; }

        //public List<UserAction> Actions { get; set; }
    }
}
