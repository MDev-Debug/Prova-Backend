using ToDo.List.Domain.Domain;

namespace ToDo.List.Domain.Models;
using System;

public class Tarefa : BaseEntity
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public Guid AccountId { get; set; }

    public Tarefa() { }

    public Tarefa(string titulo, string descricao, Guid accountId)
    {
        Titulo = titulo;
        Descricao = descricao;
        AccountId = accountId;
        DataCriacao = DateTime.Now;
        DataConclusao = DateTime.Now;
    }
}
