using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gol.Api.Dto
{
    public class AirplaneDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get;  set; }
        public DateTime DataCadastro { get;  set; }
    }
}
