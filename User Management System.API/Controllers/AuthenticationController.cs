using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using User_Management_System.Data.Contracts;
using User_Management_System.Entities.Identity;
using User_Management_System.Entities.User;

namespace User_Management_System.API.Controllers;

[Route("authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;

    public AuthenticationController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequest)
    {
        var user = ValidateUserCredentials(authenticationRequest.Email, authenticationRequest.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        var securitykey =
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
        var signingCredentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("UserName", user.UserName));
        claimsForToken.Add(new Claim(ClaimTypes.Email, user.Email));
        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );
        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);
        return Ok(tokenToReturn);
    }

    private User ValidateUserCredentials(string? email, string? password)
    {
        return _userRepository.GetUserByEmailAndPassword(email, password);
    }
}