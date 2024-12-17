using Microsoft.EntityFrameworkCore;
using ToDo.List.Domain.Domain;
using ToDo.List.Domain.Models;
using ToDo.List.Infra.Data.Configuration;

namespace ToDo.List.Infra.Data.Data;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> context)
        : base(context) { }

    public DbSet<Account> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefaMap());

        base.OnModelCreating(modelBuilder);
    }
}
