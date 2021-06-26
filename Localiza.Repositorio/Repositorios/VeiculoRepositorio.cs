using Localiza.Dominio.Contratos;
using Localiza.Dominio.Entidades;
using Localiza.Repositorio.Contexto;

namespace Localiza.Repositorio.Repositorios
{
    public class VeiculoRepositorio : BaseRepositorio<Veiculo>, IVeiculoRepositorio
    {
        public VeiculoRepositorio(LocalizaContexto localizaContexto) : base(localizaContexto)
        {
        }
    }
}
