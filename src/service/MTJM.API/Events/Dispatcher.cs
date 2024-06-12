using MTJM.API.Listeners;

namespace MTJM.API.Events;

public class Dispatcher : IDispatcher
{
    private readonly IEnumerable<IListenerBase> _listeners;

    public Dispatcher(IEnumerable<IListenerBase> listeners)
    {
        _listeners = listeners;
    }

    public async Task Publish<T>(T message)
    {
        foreach (var listener in _listeners.OfType<IListener<T>>())
        {
            await listener.HandleMessage(message);
        }
    }
}
