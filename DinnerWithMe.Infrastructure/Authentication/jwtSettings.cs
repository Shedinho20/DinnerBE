namespace DinnerWithMe.Infrastructure.Authentication
{
    public class jwtSettings
    {
        public const string  sectionName = "JwtSettings";
        public string secret { get; init; }=null!;
        public string issuer { get; init; }=null!;
        public string audience { get; init; }=null!;
        public int expiresIn { get; init; }

    }
}