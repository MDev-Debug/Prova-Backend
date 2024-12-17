using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.List.Domain.Models;

namespace ToDo.List.Infra.Data.Configuration;

public class TarefaMap : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefa");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .HasColumnName("Titulo")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.DataCriacao)
            .HasColumnName("DataCriacao")
            .IsRequired();

        builder.Property(x => x.DataConclusao)
            .HasColumnName("DataConclusao")
            .IsRequired();

        builder.Property(x => x.AccountId)
            .HasColumnName("IdUsuario")
            .IsRequired();

    }
}
