using Backend.Hubs;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    //new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    //new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                };
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eeeeeeeeeeeeeeeeenagyonhosszutitkoskodhelye"));
                var token = new JwtSecurityToken(
                 issuer: "http://www.security.org", audience: "http://www.security.org",
                 claims: claim, expires: DateTime.Now.AddDays(1),
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    id = user.Id
                });
            }
            return Unauthorized();
        }

        [HttpPut]
        public async Task<IActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            
            var oldUser = await _userManager.FindByNameAsync(model.UserName);
            if (oldUser != null) return BadRequest(JsonConvert.SerializeObject("A user with this username is already registered."));
            var email = await _userManager.FindByEmailAsync(model.Email);
            if (email != null) return BadRequest(JsonConvert.SerializeObject("A user with this email is already registered."));
            if (model.Password.Length < 8) return BadRequest(JsonConvert.SerializeObject("The length of password must be 8 characters."));
            
            var user = new AppUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Image = model.Image,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            await _userManager.CreateAsync(user, model.Password);
            return Ok();
        }
    }
}
