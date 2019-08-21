namespace Gol.Dominio.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}