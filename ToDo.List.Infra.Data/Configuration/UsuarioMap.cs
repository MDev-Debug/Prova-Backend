using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.List.Domain.Domain;

namespace ToDo.List.Infra.Data.Configuration;

public class UsuarioMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nome)
            .HasMaxLength(100)
            .HasColumnName("Nome")
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .HasColumnName("Email")
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Senha)
            .HasMaxLength(255)
            .HasColumnName("Senha")
            .IsRequired();
    }
}
