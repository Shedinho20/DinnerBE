using DinnerWithMe.Contracts.Auth;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using DinnerWithMe.Domain.Common.Errors;
using MediatR;
using DinnerWithMe.Application.AuthenticationServices.Commands;
using DinnerWithMe.Application.AuthenticationServices.Queries;
using DinnerWithMe.Application.AuthenticationServices.Common;
using MapsterMapper;

namespace DinnerWithMe.Api.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
      private readonly ISender mediator;
      private readonly IMapper mapper;
      public AuthController(ISender _mediator, IMapper _mapper)
      {
            mediator = _mediator;
            mapper = _mapper;
      }

      [HttpPost("login")]
      public async Task<IActionResult> Login(LoginRequest request)
      {
            var query = mapper.Map<LoginQuery>(request);
            ErrorOr<AuthRes> authResult = await mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvaildCred){
               return Problem(statusCode:StatusCodes.Status401Unauthorized,title:authResult.FirstError.Description);
            }


            return authResult.Match(authResult => Ok(mapper.Map<AuthResult>(authResult)), errors=>Problem(errors));
      }

      [HttpPost("register")]
      public async Task<IActionResult> Register(RegisterRequest request)
      {
         
            var command = mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthRes> authResult = await mediator.Send(command);

            return authResult.Match(authResult => Ok(mapper.Map<AuthResult>(authResult)), errors=>Problem(errors));
      }

}