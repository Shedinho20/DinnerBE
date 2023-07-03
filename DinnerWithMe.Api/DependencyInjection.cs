using DinnerWithMe.Api.Common.Errors;
using DinnerWithMe.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DinnerWithMe.Api;

public static class DependencyInjection
{
      public static IServiceCollection AddApiLayer(this IServiceCollection services)
      {
            services.AddControllers();
            services.AddMapping();
            services.AddSingleton<ProblemDetailsFactory,DinnerProblemDetailsFactory>();

            return services;
      }
}