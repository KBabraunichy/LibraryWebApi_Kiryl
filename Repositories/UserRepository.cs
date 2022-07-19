using LibraryWebApi.Interfaces;
using LibraryWebApi.Models;

namespace LibraryWebApi.Repositories
{
    public class UserRepository : IAuthRepository<User, UserLogin>
    {
        private LibraryContext db;

        public UserRepository()
        {
            db = new LibraryContext();
        }

        public User Authenticate(UserLogin user)
        {
            var currentUser = db.Users.FirstOrDefault(o => o.Username.ToLower() == user.Username.ToLower().Trim() && o.Password == user.Password);

            if (currentUser != null)
                return currentUser;
            return null;
        }
        public async Task<User> Registration(User user)
        {
            var result = await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public bool RegistrationCheck(User user)
        {
            var checkedUser = db.Users.FirstOrDefault(o => o.Username.ToLower().Trim() == user.Username.ToLower().Trim() || 
                                                      o.Email.ToLower().Trim() == user.Email.ToLower().Trim());

            if (checkedUser != null)
                return true;
            return false;

        }

    }
}
