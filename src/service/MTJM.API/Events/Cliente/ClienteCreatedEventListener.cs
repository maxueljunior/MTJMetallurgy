using MTJM.API.DTOs.Auth;
using MTJM.API.Listeners;
using MTJM.API.Services.Auth;

namespace MTJM.API.Events.Cliente;

public class ClienteCreatedEventListener : IListener<ClienteCreatedEvent>
{
    private readonly IAuthServices _authServices;

    public ClienteCreatedEventListener(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    public async Task HandleMessage(ClienteCreatedEvent message)
    {
        await _authServices.Register(GenerateCreateUser(message));
    }

    private RegisterDTO GenerateCreateUser(ClienteCreatedEvent clienteCreatedEvent)
    {
        var email = string.Concat(clienteCreatedEvent.Username, "@mtjmetallurgy.com");
        var password = "MTJMetallurgy#123";

        return new RegisterDTO
        {
            Username = clienteCreatedEvent.Username,
            Email = email,
            Password = password
        };
    }
}

