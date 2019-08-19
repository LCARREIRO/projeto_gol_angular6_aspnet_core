using Gol.Dominio.Entidades;
using Gol.Dominio.Interfaces.Repositorio;
using Gol.Dominio.Interfaces.Servico;
using Gol.Dominio.Servico.ServicoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Dominio.Servico
{
    public class ServicoAirplane : ServicoBase<Airplane>, IServicoAirplane
    {
        private readonly IAirplaneRepositorio _airplaneRepositorio;

        public ServicoAirplane(IAirplaneRepositorio airplaneRepositorio)
            : base(airplaneRepositorio)
        {
            _airplaneRepositorio = airplaneRepositorio;
        }
    }
}
