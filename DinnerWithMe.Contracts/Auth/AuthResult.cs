namespace DinnerWithMe.Contracts.Auth;

public record AuthResult(
      Guid Id,
      string Email,
      string FirstName,
      string LastName,
      string Token);