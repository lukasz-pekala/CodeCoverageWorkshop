using CodeCoverageWorkshop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeCoverageWorkshop.DAL.Services
{
    public class UserRepository : IUserRepository
    {
        private IList<User> Users { get; set; }


        public void Add(User newUser)
        {
            Users.Add(newUser);
        }

        public IEnumerable<User> GetWhere(Func<User, bool> predicate)
        {
            return Users.Where(predicate).ToList();
        }
    }

    public interface IUserRepository
    {
        IEnumerable<User> GetWhere(Func<User, bool> predicate);
    }
}