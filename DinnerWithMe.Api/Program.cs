using DinnerWithMe.Api;
using DinnerWithMe.Application;
using DinnerWithMe.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
      builder.Services.AddApplication();
      builder.Services.AddApiLayer();
      builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
      app.UseHttpsRedirection();
      app.UseExceptionHandler("/error");
      app.MapControllers();
      app.Run();
}
