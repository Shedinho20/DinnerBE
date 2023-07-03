using System.ComponentModel.DataAnnotations;

namespace DinnerWithMe.Contracts.Auth;

public record RegisterRequest(
      string Email,
      [MinLength(10)] string Password,
      [MinLength(10)]string FirstName,
      string LastName);