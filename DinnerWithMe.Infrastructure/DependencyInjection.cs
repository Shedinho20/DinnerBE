using DinnerWithMe.Application.Common.Interfaces.Authentication;
using DinnerWithMe.Application.Common.Interfaces.Persistence;
using DinnerWithMe.Application.Common.Interfaces.Services;
using DinnerWithMe.Infrastructure.Authentication;
using DinnerWithMe.Infrastructure.Presistence;
using DinnerWithMe.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerWithMe.Infrastructure;



public static class DependencyInjection
{
      public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
      {
            services.Configure<jwtSettings>(configuration.GetSection(nameof(jwtSettings)));
            
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider,DateTimeProvider>();

            services.AddScoped<IUserRepository,UserRepository>();

            return services;
      }
}