using Company.API.Models.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.API.Repositories
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;
        public TokenHandler(IConfiguration configuration) {
            
            this.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public Task<string> CreateToken(Users user)
        {
            

            //create claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            //Loop into roles of users and add to claims
            user.Roles.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }

        
    }
}
