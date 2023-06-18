using AutoMapper;
using DataBase.Models;
using DataBase.Service;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentACarAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentACarAPI.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        #region Declarations

        /// <summary>
        /// Грижи се за записването в базата на информация за потребителя
        /// </summary>
        private readonly UserManager<User> userManager;

        /// <summary>
        /// Мапва един обект към друг
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Помощен клас за удостоверяване
        /// </summary>
        private readonly IUserService authHelper;

        #endregion

        #region Constructors

        public AuthenticationController(UserManager<User> userManager, IConfiguration configuration, IMapper mapper, IUserService authHelper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.authHelper = authHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Регистрира потребител
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UserRegistrationDTO userModel)
        {
            var user = mapper.Map<User>(userModel);
            var result = await userManager.CreateAsync(user, userModel.Password);

            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }

            await userManager.AddToRoleAsync(user, "User");

            return StatusCode(201);
        }

        /// <summary>
        /// Вход за потребител
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO userModel)
        {
            var user = await userManager.FindByEmailAsync(userModel.Email);

            if (user != null)
            {
                if (await userManager.CheckPasswordAsync(user, userModel.Password))
                {
                    var signingCredentials = authHelper.GetSigningCredentials();
                    var claims = await authHelper.GetClaims(user);

                    var tokenOptions = authHelper.GenerateTokenOptions(signingCredentials, claims);

                    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    return Ok(token);
                }
                else
                {
                    await userManager.AccessFailedAsync(user);
                }
            }

            return Unauthorized("Invalid Authentication");
        }

        #endregion

        //private readonly IConfiguration _configuration;
        //private readonly IUserService userService;

        //public AuthenticationController(IConfiguration configuration, IUserService userService)
        //{
        //    _configuration = configuration;
        //    this.userService = userService;
        //}

        //[HttpPost("authenticate")]
        //public async Task<ActionResult<string>> Authenticate(string userName, string password)
        //{
        //    var user = userService.Login(userName, password);
        //    if (user != null)
        //    {
        //        return NotFound();
        //    }

        //    var securityKey = new SymmetricSecurityKey(
        //        Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

        //    var signingCredentials = new SigningCredentials(
        //        securityKey, SecurityAlgorithms.HmacSha256);

        //    var claimsForToken = new List<Claim>();

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        _configuration["Authentication:Issuer"],
        //        _configuration["Authentication:Audience"],
        //        claimsForToken,
        //        DateTime.UtcNow,
        //        DateTime.UtcNow.AddHours(1),
        //        signingCredentials) ;

        //    var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        //    return Ok(tokenToReturn);
        //}
    }
}
