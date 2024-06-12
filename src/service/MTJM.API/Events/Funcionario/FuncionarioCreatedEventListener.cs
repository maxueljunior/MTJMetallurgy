using MTJM.API.DTOs.Auth;
using MTJM.API.Listeners.Orcamentista;
using MTJM.API.Services.Auth;

namespace MTJM.API.Listeners.Funcionario;

public class FuncionarioCreatedEventListener : IListener<FuncionarioCreatedEvent>
{
    private readonly IAuthServices _authServices;

    public FuncionarioCreatedEventListener(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    public async Task HandleMessage(FuncionarioCreatedEvent message)
    {
        var register = GenerateCreateUser(message);
        var result = await _authServices.Register(register);

    }

    private RegisterDTO GenerateCreateUser(FuncionarioCreatedEvent message)
    {
        var username = string.Concat(message.Nome.ToLower(), ".", message.Sobrenome.Split(" ").Last().ToLower());
        var email = string.Concat(username, "@mtjmetallurgy.com");
        var password = "MTJMetallurgy#123";

        return new RegisterDTO { Username = username, Email = email, Password = password };
    }
}