
using Library.Application.Common;
using Library.Application.Interfaces.Authentication;
using Library.Application.Interfaces.Persistance;
using Library.Domain.Entities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Authentication.Query.Login
{
    public class LoginQueryHandler: IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJWTTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJWTTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new UnauthorizedAccessException();
            }
            if (user.Password != query.Password)
            {
                throw new UnauthorizedAccessException();
            }
            var token = _tokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
