using Microsoft.AspNetCore.Mvc;
using ContactManagement.DAL11.DbContext;
using ContactManagement.DAL11.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactManagement.API11.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AppDbContext context, IConfiguration config, ILogger<AuthController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        // 🔹 REGISTER USER
        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUser user)
        {
            if (user == null)
            {
                _logger.LogWarning("Register request is null");
                return BadRequest("Invalid user data");
            }

            var exists = _context.Users.FirstOrDefault(x => x.Email == user.Email);

            if (exists != null)
            {
                _logger.LogWarning("User already exists: {Username}", user.Email);
                return BadRequest("User already exists");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User registered successfully: {Username}", user.Email);

            return Ok(new
            {
                message = "User Registered Successfully"
            });
        }

        // 🔹 LOGIN USER
        [HttpPost("login")]
        public IActionResult Login(AppUser user)
        {
            if (user == null)
            {
                _logger.LogWarning("Login request is null");
                return BadRequest("Invalid login request");
            }

            var dbUser = _context.Users
                .FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

            if (dbUser == null)
            {
                _logger.LogWarning("Invalid login attempt for user: {Username}", user.Email);
                return Unauthorized(new
                {
                    message = "Invalid username or password"
                });
            }

            var token = GenerateToken(dbUser);

            _logger.LogInformation("User logged in successfully: {Username}", dbUser.Email);

            return Ok(new
            {
                token,
                message = "Login successful"
            });
        }

        // 🔹 GENERATE JWT TOKEN
        private string GenerateToken(AppUser user)
        {
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}