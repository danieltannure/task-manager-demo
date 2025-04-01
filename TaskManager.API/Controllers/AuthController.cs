using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.Shared;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public AuthController(TaskManagerContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos");

            var user = _context.Usuarios
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user == null)
                return Unauthorized("Usuário ou senha incorretos");

            return Ok(new Usuario
            {
                Id = user.Id,
                Username = user.Username
            });

        }

        


        [HttpGet("usuarios")]
        public IActionResult ListarUsuarios()
        {
            var usuarios = _context.Usuarios
                .Select(u => new Usuario
                {
                    Id = u.Id,
                    Username = u.Username
                }).ToList();

            return Ok(usuarios);
        }

        //DEBUG: Método para verificar se a API está ativa
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("API ativa!");
        }
    }
}
