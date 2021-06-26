using Localiza.Dominio.Entidades;
using Localiza.Repositorio.Config;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Repositorio.Contexto
{
    public class LocalizaContexto : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public LocalizaContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // referenciamos as classes de mapeamento

            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
