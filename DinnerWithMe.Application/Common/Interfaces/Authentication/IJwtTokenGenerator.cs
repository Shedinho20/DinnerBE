using DinnerWithMe.Domain.Entities;

namespace DinnerWithMe.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
      string GenerateJwtToken(User user);
}