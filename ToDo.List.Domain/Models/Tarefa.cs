using ToDo.List.Domain.Domain;

namespace ToDo.List.Domain.Models;
using System;

public class Tarefa : BaseEntity
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataConclusao { get; set; }
    public Guid IdUsuario { get; set; }
    public Account Usuario { get; set; }

    public Tarefa(string titulo, string descricao, Guid idUsuario)
    {
        Titulo = titulo;
        Descricao = descricao;
        IdUsuario = idUsuario;
        DataCriacao = DateTime.Now;
        DataConclusao = DateTime.Now;
    }

    public void ConcluirTarefa()
    {
        DataConclusao = DateTime.Now;
    }
}
