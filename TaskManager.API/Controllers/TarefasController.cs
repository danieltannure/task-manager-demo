﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.DTOs;
using TaskManager.Shared;


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
        public async Task<IActionResult> GetTarefas([FromQuery] int idUsuario)
        {
            if (idUsuario == 0) // admin
            {
                var todas = await _context.Tarefas.ToListAsync();
                return Ok(todas);
            }

            var tarefas = await _context.Tarefas
                .Where(t => t.ResponsavelId == idUsuario)
                .ToListAsync();

            return Ok(tarefas);
        }

        // PUT: api/tarefas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] TarefaDto dto)
        {
            Console.WriteLine($"DEBUG: ID da URL = {id}, ID do DTO = {dto.Id}");

            if (id != dto.Id)
                return BadRequest("ID da tarefa não corresponde.");

            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
                return NotFound("Tarefa não encontrada.");

            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.DataEntrega = dto.DataEntrega;
            tarefa.Dificuldade = dto.Dificuldade;
            tarefa.Concluida = dto.Concluida;
            tarefa.ResponsavelId = dto.ResponsavelId;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/tarefas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
        {

            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
                return NotFound("Tarefa não encontrada.");

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa([FromBody] TarefaCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Titulo) ||
                string.IsNullOrWhiteSpace(dto.Dificuldade) ||
                dto.ResponsavelId == null)
            {
                return BadRequest("Campos obrigatórios não preenchidos.");
            }

            var novaTarefa = new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataEntrega = dto.DataEntrega,
                Dificuldade = dto.Dificuldade,
                ResponsavelId = dto.ResponsavelId,
                Concluida = false
            };

            _context.Tarefas.Add(novaTarefa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTarefas), new { id = novaTarefa.Id }, novaTarefa);
        }

    }

}
