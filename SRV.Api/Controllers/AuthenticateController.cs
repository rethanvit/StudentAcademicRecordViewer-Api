using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SRV.Api.Models;
using SRV.Api.Services;
using SRV.DL;
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
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticateController(IUserRepository userRepository, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = await _userRepository.GetUserByUserName(authenticationRequestBody.UserName);
            
            //Remove this when adding user with hashed password is implemented.
            //var password = _passwordHasher.HashPassword(user, authenticationRequestBody.Password);

            if(user == null)
            {
                return Unauthorized();
            }

            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, authenticationRequestBody.Password);

            if(passwordVerification == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Provided credentials do not match.");
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
                                                     DateTime.UtcNow.AddSeconds(double.Parse(_configuration["tokenExpiryInSeconds"])),
                                                     signingCredentials);
            var generatedToken = new JwtSecurityTokenHandler().WriteToken(jwtTokenData);
            return new OkObjectResult(JsonConvert.SerializeObject(generatedToken));
        }
    }
}
