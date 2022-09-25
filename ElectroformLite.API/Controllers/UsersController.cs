using ElectroformLite.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElectroformLite.API.Controllers;

[Route("users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if(user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecurityKey")));

            var token = new JwtSecurityToken
            (
                issuer: "https://localhost:7188",
                audience: "http://localhost:4200",
                claims: authClaims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(string userName, string password)
    {
        var userExists = await _userManager.FindByNameAsync(userName);

        if(userExists != null)
        {
            return BadRequest("User already exists");
        }

        User user = new()
        {
            UserName = userName
        };

        var result = await _userManager.CreateAsync(user, password);
        
        if(!result.Succeeded)
        {
            return BadRequest("Failed to create user");
        }

        return Ok("User created successfully");
    }

    [HttpPost]
    [Route("assign-role")]
    public async Task<IActionResult> AssignRole(string userName, string roleName)
    {
        var userExists = await _userManager.FindByNameAsync(userName);

        if (userExists == null)
        {
            return BadRequest("User does not exist");
        }

        var role = await _roleManager.FindByNameAsync(roleName);

        if (role == null)
        {
            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = roleName
            });
        }

        var addRoleToUser = await _userManager.AddToRoleAsync(userExists, roleName);

        if(!addRoleToUser.Succeeded)
        {
            return BadRequest("Failed to add user to role");
        }

        return Ok($"User successfully added to {roleName} role");
    }
}
