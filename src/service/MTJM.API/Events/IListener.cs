namespace MTJM.API.Listeners;

public interface IListener<T> : IListenerBase
{
    Task HandleMessage(T message);
}
