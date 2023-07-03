using DinnerWithMe.Application.AuthenticationServices.Common;
using DinnerWithMe.Application.Common.Interfaces.Authentication;
using DinnerWithMe.Application.Common.Interfaces.Persistence;
using DinnerWithMe.Domain.Common.Errors;
using DinnerWithMe.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DinnerWithMe.Application.AuthenticationServices.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery,ErrorOr<AuthRes>>
{
      private readonly IJwtTokenGenerator jwt;
      private readonly IUserRepository userRepository;

      public LoginQueryHandler(IJwtTokenGenerator _jwt,IUserRepository _userRepository)
      {
            jwt = _jwt;
            userRepository=_userRepository;
      }
      
      public async Task<ErrorOr<AuthRes>> Handle(LoginQuery request, CancellationToken cancellationToken)
      {
            if (userRepository.GetUserByEmail(request.Email) is not User user){
                  return Errors.Authentication.InvaildCred;
            }
            if (user.Password!= request.Password)
            {
                  return Errors.Authentication.InvaildCred;
            }

            string token = jwt.GenerateJwtToken(user);

            return new AuthRes(user, token);
      }
}