using BarberHouse.JWT_Token;
using BarberHouse.Models;
using BarberHouse.Models.DTOs;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarberHouse.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly byte[] _jwtSecretKey;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _jwtSecretKey = KeyGenerator.GenerateKey(256);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await _loginRepository.GetUserByEmail(model.Email);

            if (user == null)
            {
                return Unauthorized(); // Wrong E-mail
            }

            if (user.Password != model.Password)
            {
                return Unauthorized(); // Wrong Password
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(_jwtSecretKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
