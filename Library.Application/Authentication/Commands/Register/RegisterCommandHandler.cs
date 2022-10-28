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

namespace Library.Application.Authentication.Commands.Register
{
    class RegisterCommandHandler : IRequestHandler<RegisterCommand,AuthenticationResult>
    {
        private readonly IJWTTokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository, IJWTTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByEmail(command.Email) is not null)
            {
                throw new Exception("user email already exist");
            }
            var user = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };
            await _userRepository.Add(user);
            Guid userId = Guid.NewGuid();
            var token = _tokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
