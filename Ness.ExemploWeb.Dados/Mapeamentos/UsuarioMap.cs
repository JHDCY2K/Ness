using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dados
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Login)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .HasColumnType("bit")                
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(c => c.UltimoLogin)
                .HasColumnType("smalldatetime")
                .IsRequired(false);

            builder.Property(c => c.CriadoPor)
               .HasColumnType("varchar(255)")
               .HasMaxLength(255)
               .IsRequired(true);

            builder.Property(c => c.DataCriacao)
                .HasColumnType("smalldatetime")
                .IsRequired(true);

            builder.Property(c => c.AlteradoPor)
               .HasColumnType("varchar(255)")
               .HasMaxLength(255)
               .IsRequired(false);

            builder.Property(c => c.DataAlteracao)
                .HasColumnType("smalldatetime")
                .IsRequired(false);

        }
    }
}
