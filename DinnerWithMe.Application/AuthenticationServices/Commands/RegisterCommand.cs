using DinnerWithMe.Application.AuthenticationServices.Common;
using ErrorOr;
using MediatR;

namespace DinnerWithMe.Application.AuthenticationServices.Commands;


public record RegisterCommand(
      string Email,
      string Password,
      string FirstName,
      string LastName):IRequest<ErrorOr<AuthRes>>;