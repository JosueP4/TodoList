using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TO_DO_LIST.Context;
using TO_DO_LIST.Model;

namespace TO_DO_LIST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private IConfiguration _configuration;

        public LoginController (AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Autenticacion")]


        public async Task<ActionResult?> Login(Usuario usuario)
        {
            var usuarioE = await _context.Usuarios
        .SingleOrDefaultAsync(j => j.User == usuario.User && j.Password == usuario.Password);

            if(usuarioE is null)
            {
                return BadRequest("datos incorrecto");
            }
                string jwtToken = GenerateToken(usuarioE);
            return Ok(new { token = jwtToken });

        }

        private String GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.User),
                new Claim(ClaimTypes.Role, usuario.rol)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var seguridadTokens = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(60));

            string Token = new JwtSecurityTokenHandler().WriteToken(seguridadTokens);

            return Token;
        }


    }
}
