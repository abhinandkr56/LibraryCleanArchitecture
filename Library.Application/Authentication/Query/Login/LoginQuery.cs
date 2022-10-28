
using Library.Application.Common;
using MediatR;

namespace Library.Application.Authentication.Query.Login
{
    public record LoginQuery
   (
       string Email,
       string Password
   ) : IRequest<AuthenticationResult>;
}
