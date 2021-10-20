using CodeCoverageWorkshop.DAL;

namespace CodeCoverageWorkshop.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public async Task<User> Login(string username, string password)
        //{
        //    var user = await _userRepository.FirstOrDefault(x => x.Login == username);

        //    if (user == null)
        //        return null;

        //    if (!VerifyPassword(password, user.Password))
        //        return null;

        //    return user;
        //}

        //private bool VerifyPassword(string password, string passwordFromDb)
        //{
        //    return password == passwordFromDb;
        //}

        //public async Task<User> Register(User user)
        //{
        //    if (await UserExists(user.Login))
        //        return null;

        //    await _userRepository.Add(user);

        //    // TODO: return actual entity from the database
        //    return user;
        //}

        public bool UserExists(string login)
        {
            return _userRepository.GetWhere(x => x.Login == login) != null;
        }

    }

    public interface IUserService
    {
        //Task<User> Register(User user);
        //Task<User> Login(string username, string password);
        //Task<bool> UserExists(string username);
        bool UserExists(string login);
    }
}
