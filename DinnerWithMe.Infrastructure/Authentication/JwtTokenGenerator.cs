using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DinnerWithMe.Application.Common.Interfaces.Authentication;
using DinnerWithMe.Application.Common.Interfaces.Services;
using DinnerWithMe.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DinnerWithMe.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{           
     private  IDateTimeProvider dateTimeProvider;

     private readonly jwtSettings jwtSettings;


     public JwtTokenGenerator(IDateTimeProvider _dateTimeProvider,IOptions<jwtSettings> _jwtSettings)
     {
         dateTimeProvider = _dateTimeProvider;
         jwtSettings = _jwtSettings.Value;
     }

      public string GenerateJwtToken(User user)
      {        
            Claim[] claims = new[]{
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString ()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.secret)),
                    SecurityAlgorithms.HmacSha256
            );


            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.issuer,
                audience: jwtSettings.audience,
                expires: dateTimeProvider.UtcNow.AddMinutes(jwtSettings.expiresIn),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
      }
}