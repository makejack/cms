using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using www.veinid365.cn.Configs;
using www.veinid365.cn.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace www.veinid365.cn.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly AppSettings _appSetting;

        public JwtTokenService(AppSettings appSettings)
        {
            _appSetting = appSettings;
        }

        public string GenerateJwtToken(Users user)
        {
            var claims = new Claim[]{
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}