using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.List.Domain.Interfaces;
using ToDo.List.Domain.Models;

namespace ToDo.List.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly string emailUsuario;

    public TarefaController(ITarefaRepository tarefaRepository)
    {
        emailUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        _tarefaRepository = tarefaRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CriarTarefa([FromBody] Tarefa tarefa)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ObterTarefas()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterTarefa(Guid id)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody] Tarefa tarefa)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirTarefa(Guid id)
    {
        return NoContent();
    }
}