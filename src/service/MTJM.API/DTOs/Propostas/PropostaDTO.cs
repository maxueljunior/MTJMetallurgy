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
    public ICollection<PropostaProdutoDTO> Produtos { get; set; }
    public ICollection<ServicoDTO> Servicos { get; set; }

    [JsonIgnore]
    public ValidationResult ValidationResult { get; set; }

    [JsonIgnore]
    public List<string> Errors { get; private set; } = new List<string>();

    public static implicit operator PropostaDTO(Proposta p)
    {
        var produtosDTO = new List<PropostaProdutoDTO>();

        foreach(var produto in p.PropostaProdutos)
        {
            produtosDTO.Add(produto);
        }

        var servicosDTO = new List<ServicoDTO>();

        foreach (var servico in p.Servicos)
        {
            servicosDTO.Add(servico);
        }

        return new PropostaDTO
        {
            Id = p.Id,
            ValorTotal = p.ValorTotal,
            Prazo = p.Prazo,
            Status = p.Status,
            ClienteId = p.ClienteId,
            CoordenadorRegionalId = p.CoordenadorRegionalId,
            OrcamentistaId = p.OrcamentistaId,
            Produtos = produtosDTO,
            Servicos = servicosDTO,
            ValidationResult = p.ValidationResult
        };
    }

    public void AddError(string message) => Errors.Add(message);
}
