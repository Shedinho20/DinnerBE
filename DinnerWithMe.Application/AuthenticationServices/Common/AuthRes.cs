using DinnerWithMe.Domain.Entities;

namespace DinnerWithMe.Application.AuthenticationServices.Common;

public record AuthRes(User user, string Token);