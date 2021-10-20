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
    }
}
