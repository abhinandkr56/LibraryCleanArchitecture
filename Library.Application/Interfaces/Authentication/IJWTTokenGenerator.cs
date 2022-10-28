using Library.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(User user);
    }
}
