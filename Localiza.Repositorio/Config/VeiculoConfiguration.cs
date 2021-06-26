using Localiza.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Localiza.Repositorio.Config
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);

            builder
                .Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(8);

            builder
                .Property(v => v.CodChassi)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(v => v.CodRenavan)
                .IsRequired()
                .HasMaxLength(12);

            builder
               .Property(v => v.Marca)
               .IsRequired()
               .HasMaxLength(20);

            builder
               .Property(v => v.Modelo)
               .IsRequired()
               .HasMaxLength(20);

            builder
                .Property(v => v.Ano)
                .IsRequired()
                .HasMaxLength(4);

        }
    }
}
