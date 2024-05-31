using FluentValidation.Results;
using MTJM.API.DTOs.Produtos;
using MTJM.API.DTOs.Servicos;
using MTJM.API.Models.Propostas;
using System.Text.Json.Serialization;

namespace MTJM.API.DTOs.Propostas;

public class PropostaDTO
{
    public PropostaDTO()
    {
        ValidationResult = new ValidationResult();
    }

    public int Id { get; set; }
    public decimal? ValorTotal { get; set; }
    public int? Prazo { get; set; }
    public Status Status { get; set; }
    public int ClienteId { get; set; }
    public int CoordenadorRegionalId { get; set; }
    public int OrcamentistaId { get; set; }
    public ICollection<ProdutoDTO> Produtos { get; set; }
    public ICollection<ServicoDTO> Servicos { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    [JsonIgnore]
    public List<string> Errors { get; private set; } = new List<string>();

    public static implicit operator PropostaDTO(Proposta p)
        => new PropostaDTO
        {
            Id = p.Id,
            ValorTotal = p.ValorTotal,
            Prazo = p.Prazo,
            Status = p.Status,
            ClienteId = p.ClienteId,
            CoordenadorRegionalId = p.CoordenadorRegionalId,
            OrcamentistaId = p.OrcamentistaId,
            Produtos = (ICollection<ProdutoDTO>) p.Produtos,
            Servicos = (ICollection<ServicoDTO>) p.Servicos,
            ValidationResult = p.ValidationResult
        };

    public void AddError(string message) => Errors.Add(message);
}
