namespace MTJM.API.Events;

public interface IDispatcher
{
    Task Publish<T>(T message);
}
