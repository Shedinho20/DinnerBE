using System.ComponentModel.DataAnnotations;

namespace DinnerWithMe.Contracts.Auth;

public record LoginRequest(string Email, [MinLength(10)] string Password);