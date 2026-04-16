using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AuthService.Data;
using AuthService.Models;
using AuthService.Services;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(AuthDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        // 🔐 REGISTER
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            // ✅ Check if user already exists
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
                return BadRequest("User already exists");

            // 🔐 Hash Password
            user.Password = HashPassword(user.Password);

            // ✅ Default role
            if (string.IsNullOrEmpty(user.Role))
                user.Role = "User";

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new
            {
                message = "User Registered Successfully"
            });
        }

        // 🔐 LOGIN
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email);

            if (user == null)
                return Unauthorized("Invalid email or password");

            // 🔐 Verify Password
            if (!VerifyPassword(login.Password, user.Password))
                return Unauthorized("Invalid email or password");

            var token = _jwt.GenerateToken(user);

            return Ok(new
            {
                token = token,
                email = user.Email,
                role = user.Role
            });
        }

        // 🔒 PASSWORD HASHING METHOD
        private string HashPassword(string password)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // 🔒 PASSWORD VERIFY
        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            var hashInput = HashPassword(inputPassword);
            return hashInput == storedPassword;
        }
    }
}