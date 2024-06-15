namespace MTJM.API.Events.Cliente;

public class ClienteCreatedEvent
{
    public string Username { get; set; }

    public ClienteCreatedEvent(string username)
    {
        Username = username;
    }
}
