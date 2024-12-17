using ToDo.List.Domain.Models;

namespace ToDo.List.Domain.Interfaces;

public interface ITarefaRepository
{
    Task<Tarefa> CriarTarefaAsync(Tarefa tarefa, Guid usuarioId);
    Task<List<Tarefa>> ObterTarefasPorUsuarioAsync(Guid usuarioId);
    Task<Tarefa> ObterTarefaPorIdAsync(Guid tarefaId, Guid usuarioId);
    Task<Tarefa> AtualizarTarefaAsync(Guid tarefaId, Tarefa tarefaAtualizada, Guid usuarioId);
    Task<bool> ExcluirTarefaAsync(Guid tarefaId, Guid usuarioId);
}
