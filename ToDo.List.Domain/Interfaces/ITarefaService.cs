using ToDo.List.Domain.Models;

namespace ToDo.List.Domain.Interfaces
{
    public interface ITarefaService
    {
        Task<Tarefa> CriarTarefaAsync(Tarefa tarefa, string emailUsuario);
        Task<List<Tarefa>> ObterTarefasPorUsuarioAsync(string emailUsuario);
        Task<Tarefa> ObterTarefaPorIdAsync(Guid tarefaId, string emailUsuario);
        Task<Tarefa> AtualizarTarefaAsync(Guid tarefaId, Tarefa tarefaAtualizada, string emailUsuario);
        Task<bool> ExcluirTarefaAsync(Guid tarefaId, string emailUsuario);
    }
}
