using DataBase.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Service.Impl
{
    public class UserService : IUserService
    {
        #region Declarations
        /// <summary>
        /// Грижи се за записването в базата на информация за потребителя
        /// </summary>
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Настройки за jwt тоукенът
        /// </summary>
        private readonly IConfigurationSection jwtSettings;

        #endregion

        #region Constructors

        public UserService(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            jwtSettings = configuration.GetSection("Authentication");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Създава credentials за вход на потребителя
        /// </summary>
        /// <returns></returns>
        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(jwtSettings.GetSection("SecretForKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Генерира jwtSecurityToken, чрез който след това се създава jwt тоукенът
        /// </summary>
        /// <param name="signingCredentials"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                audience: jwtSettings.GetSection("Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("Expire").Value)),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        /// <summary>
        /// Създава claim-ове за потребителя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var roles = await userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim("Role", role));
            }

            return claims;
        }

        #endregion
    }
}
