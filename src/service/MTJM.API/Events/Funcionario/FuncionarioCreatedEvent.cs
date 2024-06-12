namespace MTJM.API.Listeners.Orcamentista;

public class FuncionarioCreatedEvent
{
    public string Nome { get; }
    public string Sobrenome { get; }

    public FuncionarioCreatedEvent(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
}
