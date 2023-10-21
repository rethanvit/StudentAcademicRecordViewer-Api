using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SRV.Api.Models;
using SRV.Api.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SRV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = await _userRepository.ValidateUserCredentialAsync(authenticationRequestBody.UserName, authenticationRequestBody.Password);

            if(user == null)
            {
                return Unauthorized();
            }

            //create token
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>() {
                new Claim("sub", user.UserId.ToString()),
                new Claim("userName", user.Username),
                new Claim("userRole", user.UserRoleCode)
            };

            var jwtTokenData = new JwtSecurityToken(_configuration["Authentication:Issuer"],
                                                     _configuration["Authentication:Audience"],
                                                     claimsForToken,
                                                     DateTime.UtcNow,
                                                     DateTime.UtcNow.AddMinutes(10),
                                                     signingCredentials);
            var generatedToken = new JwtSecurityTokenHandler().WriteToken(jwtTokenData);
            return JsonConvert.SerializeObject(generatedToken);
        }
    }
}
