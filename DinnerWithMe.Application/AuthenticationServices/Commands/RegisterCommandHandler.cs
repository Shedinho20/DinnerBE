using DinnerWithMe.Application.AuthenticationServices.Common;
using DinnerWithMe.Application.Common.Interfaces.Authentication;
using DinnerWithMe.Application.Common.Interfaces.Persistence;
using DinnerWithMe.Domain.Common.Errors;
using DinnerWithMe.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DinnerWithMe.Application.AuthenticationServices.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand,ErrorOr<AuthRes>>
{
      private readonly IJwtTokenGenerator jwt;
      private readonly IUserRepository userRepository;

      public RegisterCommandHandler(IJwtTokenGenerator _jwt,IUserRepository _userRepository)
      {
            jwt = _jwt;
            userRepository=_userRepository;
      }
      public async Task<ErrorOr<AuthRes>> Handle(RegisterCommand request, CancellationToken cancellationToken)
      {
             if (userRepository.GetUserByEmail(request.Email) is not null){
                  return  Errors.User.DuplicateEmail;
            }

            var user = new User
            {
                  Id = Guid.NewGuid(),
                  FirstName = request.FirstName,
                  LastName = request.LastName,
                  Password = request.Password,
                  Email = request.Email
            };

            userRepository.AddUser(user);

            string token = jwt.GenerateJwtToken(user);

            return new AuthRes(user, token);
      }
}