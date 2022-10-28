using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistance.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private LibraryDbContext _userContext = null;
        public UserRepository()
        {
            _userContext = new LibraryDbContext();
        }
        public async Task<bool> Add(User user)
        {
            _userContext.Users.Add(user);
            var a = await _userContext.SaveChangesAsync();
            return a > 0;
        }

        public async Task<User> GetUserByEmail(string Email)
        {
            return _userContext.Users.SingleOrDefault(x => x.Email == Email);
        }
    }
}
