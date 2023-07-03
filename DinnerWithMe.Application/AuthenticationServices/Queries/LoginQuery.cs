using DinnerWithMe.Application.AuthenticationServices.Common;
using ErrorOr;
using MediatR;

namespace DinnerWithMe.Application.AuthenticationServices.Queries;


public record LoginQuery(
      string Email,
      string Password
            ):IRequest<ErrorOr<AuthRes>>;