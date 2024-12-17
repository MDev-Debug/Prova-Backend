using ToDo.List.Domain.Interfaces;
using ToDo.List.Domain.Models;

namespace ToDo.List.Domain.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IAccountRepository _accountRepository;

    public TarefaService(ITarefaRepository repository, IAccountRepository accountRepository)
    {
        _tarefaRepository = repository;
        _accountRepository = accountRepository;
    }

    public async Task<Tarefa> AtualizarTarefaAsync(Guid tarefaId, Tarefa tarefaAtualizada, string emailUsuario)
    {
        var user = await _accountRepository.BuscarContaPorEmail(emailUsuario);

        if (user == null)
            return null;

        var tarefa = await _tarefaRepository.AtualizarTarefaAsync(tarefaId, tarefaAtualizada, user.Id);
        return tarefa;

    }

    public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa, string emailUsuario)
    {
        var user = await _accountRepository.BuscarContaPorEmail(emailUsuario);

        if (user == null)
            return null;

        tarefa.AccountId = user.Id;
        await _tarefaRepository.CriarTarefaAsync(tarefa);
        return tarefa;
    }

    public async Task<bool> ExcluirTarefaAsync(Guid tarefaId, string emailUsuario)
    {
        var user = await _accountRepository.BuscarContaPorEmail(emailUsuario);
        if (user == null)
            return false;

        await _tarefaRepository.ExcluirTarefaAsync(tarefaId, user.Id);
        return true;
    }

    public async Task<Tarefa> ObterTarefaPorIdAsync(Guid tarefaId, string emailUsuario)
    {
        var user = await _accountRepository.BuscarContaPorEmail(emailUsuario);
        if (user == null)
            return null;

        var tarefa = await _tarefaRepository.ObterTarefaPorIdAsync(tarefaId, user.Id);
        return tarefa;
    }

    public async Task<List<Tarefa>> ObterTarefasPorUsuarioAsync(string emailUsuario)
    {
        var user = await _accountRepository.BuscarContaPorEmail(emailUsuario);
        if (user == null)
            return new List<Tarefa>();

        var tarefas = await _tarefaRepository.ObterTarefasPorUsuarioAsync(user.Id);
        return tarefas;
    }
}
