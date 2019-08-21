using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gol.Api.Dto
{
    public class AirplaneDTO : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get;  set; }
        public DateTime DataCadastro { get;  set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(Codigo, 120, "Codigo", "O título deve conter até 120 caracteres")
                .HasMinLen(Modelo, 3, "Codigo", "O título deve conter pelo menos 3 caracteres")
                .HasMaxLen(Codigo, 120, "Modelo", "O modelo deve conter até 120 caracteres")
                .HasMinLen(Modelo, 3, "Modelo", "O modelo deve conter pelo menos 3 caracteres")
                .IsGreaterThan(QuantidadePassageiros, 0, "Quantidade", "Informe um número maior que zero")
            );
        }
    }
}
