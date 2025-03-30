using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.Shared;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public TarefaController(TaskManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tarefas = await _context.Tarefas
                .Include(t => t.Responsavel)
                .ToListAsync();

            return Ok(tarefas);
        }
    }
}
