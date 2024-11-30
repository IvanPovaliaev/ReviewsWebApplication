using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = Reviews.Application.Helpers.ConfigurationManager;

namespace ReviewsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Login to system
        /// </summary>
        /// <returns>Ok status code with token; Unauthorized if input data is incorrect</returns>
        /// <param name="login">LoginDTO model</param>

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            if (login is null)
            {
                return BadRequest("Invalid user request!!!");
            }

            var isLoginValid = _loginService.CheckLogin(login);

            if (isLoginValid)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.UtcNow.AddMinutes(6),
                    signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }

            return Unauthorized();
        }
    }
}
