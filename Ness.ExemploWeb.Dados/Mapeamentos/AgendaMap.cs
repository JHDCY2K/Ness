using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ness.ExemploWeb.Dominio.Entidades;

namespace Ness.ExemploWeb.Dados
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.IdCliente)
                .HasColumnType("long")
               .IsRequired(true);

            builder.Property(c => c.DataAgenda)
                .HasColumnType("smalldatetime")
                .IsRequired(true);


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
