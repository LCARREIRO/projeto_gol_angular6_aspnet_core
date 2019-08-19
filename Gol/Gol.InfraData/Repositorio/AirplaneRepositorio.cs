using Gol.Dominio.Entidades;
using Gol.Dominio.Interfaces.Repositorio;
using Gol.InfraData.Contexto;

namespace Gol.InfraData.Repositorio
{
    public class AirplaneRepositorio : RepositorioBase<Airplane>, IAirplaneRepositorio
    {
        private readonly EfDbContext _efdbontext;

        public AirplaneRepositorio(EfDbContext efdbontext) 
            : base(efdbontext)
        {
            _efdbontext = efdbontext;
        }
    }
}
