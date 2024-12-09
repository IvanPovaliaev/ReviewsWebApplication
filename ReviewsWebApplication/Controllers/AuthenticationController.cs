using Microsoft.AspNetCore.Mvc;
using Reviews.Application.Interfaces;
using Reviews.Application.Models;
using ReviewsWebApplication.Helpers;

namespace ReviewsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly JwtProvider _jwtProvider;

        public AuthenticationController(ILoginService loginService, JwtProvider jwtProvider)
        {
            _loginService = loginService;
            _jwtProvider = jwtProvider;
        }

        /// <summary>
        /// Login to system
        /// </summary>
        /// <returns>Ok status code with token; Unauthorized if input data is incorrect</returns>
        /// <param name="login">LoginDTO model</param>

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (login is null)
            {
                return BadRequest("Invalid user request!");
            }

            var isLoginValid = await _loginService.CheckLoginAsync(login);

            if (isLoginValid)
            {
                var token = _jwtProvider.GenerateToken();

                return Ok(new JWTTokenResponse
                {
                    Token = token
                });
            }

            return Unauthorized();
        }
    }
}
