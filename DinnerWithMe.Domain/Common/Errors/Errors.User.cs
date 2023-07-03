using ErrorOr;

namespace DinnerWithMe.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
              code: "DuplicateEmail",
              description: "Email already in use");
    }
}