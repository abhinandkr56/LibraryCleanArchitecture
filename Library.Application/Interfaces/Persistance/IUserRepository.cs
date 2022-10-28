using Library.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.Persistance
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string Email);
        Task<bool> Add(User user);
    }
}
