

using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tsogosun.com.MSProfileAdmin.Service.Interface;

namespace tsogosun.com.MSProfileAdmin.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly string _key;

        public AuthManager(string key)
        {
            _key = key;
        }

        public string Authenticate(string username)
        {
            // Create JWT Token, if it matches
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            // it will return token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // JWT will be returned from here
            return tokenHandler.WriteToken(token);
        }
    }
}