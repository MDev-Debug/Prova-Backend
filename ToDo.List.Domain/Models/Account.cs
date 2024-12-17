using ToDo.List.Domain.Models;

namespace ToDo.List.Domain.Domain;

public sealed class Account : BaseEntity
{
    public Account(string nome,
                   string email,
                   string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Tarefas = new List<Tarefa>();
    }

    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public ICollection<Tarefa> Tarefas { get; set; }
}
