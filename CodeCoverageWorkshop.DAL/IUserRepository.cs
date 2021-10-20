using System;
using System.Collections.Generic;
using System.Linq;
using CodeCoverageWorkshop.DAL.Models;

namespace CodeCoverageWorkshop.DAL
{
    public class UserRepository : IUserRepository
    {
        private IList<User> Users { get; set; } = new List<User>();


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