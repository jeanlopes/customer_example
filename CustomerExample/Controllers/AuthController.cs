using CustomerExample.Application.Interfaces;
using CustomerExampleWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerExampleWeb.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [SwaggerTag("Authentication")]
    public class AuthController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserAppService userAppService, IConfiguration configuration)
        {
            _userAppService = userAppService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation("Authenticate", "Authenticates a user")]
        [SwaggerResponse(200, "Authentication successful", typeof(AuthenticationRequestModel))]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequestModel model)
        {
            var user = await _userAppService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["Jwt:SecretKey"] ?? throw new Exception("SecretKey not found in appsettings.json file");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            Response.Cookies.Append("jwt", tokenString, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            return Ok(new { Token = tokenString });
        }

        [HttpGet("logout")]
        [Authorize]
        [SwaggerOperation("Logout", "Logs out the current user")]
        [SwaggerResponse(200, "Logout successful")]
        [SwaggerResponse(401, "Unauthorized")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok();
        }
    }
}
