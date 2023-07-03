using ErrorOr;

namespace DinnerWithMe.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvaildCred => Error.Validation(
              code: "Auth.InvaildCred",
              description: "Invalid user credentials");
    }
}