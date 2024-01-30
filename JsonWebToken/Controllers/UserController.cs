using Azure.Core;
using JsonWebToken.Dto;
using JsonWebToken.Dto.User;
using JsonWebToken.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _appDbContext;

        public UserController(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IActionResult> Add([FromForm] UserDtoAdd request)
        {
            User user = request.Map(request);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.password);
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return Ok(new { id = user.Id });
        }
        [HttpPost("Login"),AllowAnonymous]
        public async Task<ActionResult<User>> Login(UserLoginDto userDto)
        {
            
            var user = _appDbContext.Users.SingleOrDefault(x => x.UserName == userDto.userName && x.Password ==userDto.password);
            if (user == null)
            {
                return BadRequest("yanlış");
            }
            var Role = await _appDbContext.Roles.FindAsync(user.RoleId);
            user.Role = Role;
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User User)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,User.UserName),
                new Claim(ClaimTypes.Role,User.Role.Rolename)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
