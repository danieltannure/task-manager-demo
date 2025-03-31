using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;


namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly TaskManagerContext _context;

        public TarefasController(TaskManagerContext context)
        {
            _context = context;
        }

        // Endpoint para obter todas as tarefas
        [HttpGet]
        public async Task<IActionResult> GetTarefas()
        {
            var tarefas = await _context.Tarefas.ToListAsync();
            return Ok(tarefas);
        }
    }
}
