using Microsoft.IdentityModel.Tokens;
using Redis.Business.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Redis.Business.Auth
{
    public class TokenService
    {
        public static readonly string PrivateKey = "PO$TAT$%O21!3%^BWU**12!@WEHFB23!G23&289#628!342BE891%2E1E#1Y2";

        public string Generate(Usuario usuario)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(PrivateKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = GenerateClaims(usuario),
            };
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(Usuario user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name ?? "no-name-set"));
            ci.AddClaim(new Claim("id", user.Id.ToString()));

            Permission permission = (Permission)user.IdPermission;

            ci.AddClaim(new Claim(ClaimTypes.Role, permission.ToString()));

            return ci;

        }
    }
}
