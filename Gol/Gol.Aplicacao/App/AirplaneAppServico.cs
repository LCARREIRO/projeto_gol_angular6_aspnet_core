using Gol.Dominio.Interfaces.Servico;
using Gol.Aplicacao.App.Base;
using Gol.Aplicacao.Interfaces;
using Gol.Dominio.Entidades;

namespace Gol.Aplicacao.App
{
    public class AirplaneAppServico : AppServicoBase<Airplane>, IAirplaneAppServico
    {
        private readonly IServicoAirplane _servicoAirplane;

        public AirplaneAppServico(IServicoAirplane servicoAirplane)
            :base(servicoAirplane)
        {
            _servicoAirplane = servicoAirplane;
        }
    }
}
