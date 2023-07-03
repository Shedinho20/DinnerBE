
using DinnerWithMe.Application.AuthenticationServices.Commands;
using DinnerWithMe.Application.AuthenticationServices.Common;
using DinnerWithMe.Application.AuthenticationServices.Queries;
using DinnerWithMe.Contracts.Auth;
using Mapster;

namespace DinnerWithMe.Api.Common.Mapping;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest,LoginQuery>();

        config.NewConfig<RegisterRequest,RegisterCommand>();
        
        config.NewConfig<AuthRes,AuthResult>()
          .Map(dest => dest, src => src.user);
    }
}