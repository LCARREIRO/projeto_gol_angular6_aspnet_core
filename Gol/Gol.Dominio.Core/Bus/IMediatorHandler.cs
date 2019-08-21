using System.Threading.Tasks;
using Gol.Dominio.Core.Commands;
using Gol.Dominio.Core.Events;


namespace Gol.Dominio.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
