using Microsoft.EntityFrameworkCore;
using ToDo.List.Domain.Interfaces;
using ToDo.List.Domain.Models;
using ToDo.List.Infra.Data.Data;

namespace ToDo.List.Infra.Data.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly ToDoListDbContext _context;

    public TarefaRepository(ToDoListDbContext context)
    {
        _context = context;
    }

    public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }

    public async Task<List<Tarefa>> ObterTarefasPorUsuarioAsync(Guid usuarioId)
    {
        return await _context.Tarefas
            .Where(t => t.AccountId == usuarioId)
            .ToListAsync();
    }

    public async Task<Tarefa> ObterTarefaPorIdAsync(Guid tarefaId, Guid usuarioId)
    {
        return await _context.Tarefas
            .FirstOrDefaultAsync(t => t.Id == tarefaId && t.AccountId == usuarioId);
    }

    public async Task<Tarefa> AtualizarTarefaAsync(Guid tarefaId, Tarefa tarefaAtualizada, Guid usuarioId)
    {
        var tarefa = await _context.Tarefas
            .FirstOrDefaultAsync(t => t.Id == tarefaId && t.AccountId == usuarioId);

        if (tarefa == null)
            return null;

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Descricao = tarefaAtualizada.Descricao;
        tarefa.DataConclusao = tarefaAtualizada.DataConclusao;

        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }

    public async Task<bool> ExcluirTarefaAsync(Guid tarefaId, Guid usuarioId)
    {
        var tarefa = await _context.Tarefas
            .FirstOrDefaultAsync(t => t.Id == tarefaId && t.AccountId == usuarioId);

        if (tarefa == null)
            return false;

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return true;
    }
}