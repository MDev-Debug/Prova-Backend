using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.List.Domain.Interfaces;
using ToDo.List.Domain.Models;

namespace ToDo.List.API.Controllers;

[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarTarefa([FromBody] Tarefa tarefa)
    {
        var emailUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(emailUsuario))
            return Unauthorized("Usuário não autenticado.");

        var tarefaCriada = await _tarefaService.CriarTarefaAsync(tarefa, emailUsuario);

        if (tarefaCriada == null)
            return BadRequest("Não foi possível criar a tarefa.");

        return Ok(tarefaCriada);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTarefas()
    {
        var emailUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(emailUsuario))
            return Unauthorized("Usuário não autenticado.");

        var tarefas = await _tarefaService.ObterTarefasPorUsuarioAsync(emailUsuario);

        if (tarefas == null || tarefas.Count == 0)
            return NotFound("Nenhuma tarefa encontrada.");

        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterTarefa(Guid id)
    {
        var emailUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(emailUsuario))
            return Unauthorized("Usuário não autenticado.");

        var tarefa = await _tarefaService.ObterTarefaPorIdAsync(id, emailUsuario);

        if (tarefa == null)
            return NotFound("Tarefa não encontrada ou não pertence ao usuário.");

        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody] Tarefa tarefa)
    {
        var emailUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(emailUsuario))
            return Unauthorized("Usuário não autenticado.");

        var tarefaAtualizada = await _tarefaService.AtualizarTarefaAsync(id, tarefa, emailUsuario);

        if (tarefaAtualizada == null)
            return NotFound("Tarefa não encontrada ou não pertence ao usuário.");

        return Ok(tarefaAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirTarefa(Guid id)
    {
        var emailUsuario = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(emailUsuario))
            return Unauthorized("Usuário não autenticado.");

        var excluida = await _tarefaService.ExcluirTarefaAsync(id, emailUsuario);

        if (!excluida)
            return NotFound("Tarefa não encontrada ou não pertence ao usuário.");

        return NoContent();
    }
}