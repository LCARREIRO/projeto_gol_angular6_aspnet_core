using Gol.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.InfraData.Mapeamento
{
    public class AirplaneMap : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(k => k.Id)
                 .HasName("Id");

            builder.Property(p => p.Id)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(p => p.Codigo)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(p => p.Modelo)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.QuantidadePassageiros)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();           

        }
    }
}
