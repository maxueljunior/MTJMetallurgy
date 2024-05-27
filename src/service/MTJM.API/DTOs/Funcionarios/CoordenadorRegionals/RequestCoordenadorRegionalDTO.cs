﻿using MTJM.API.Models.Enderecos;
using MTJM.API.Models.Funcionarios;

namespace MTJM.API.DTOs.Funcionarios.CoordenadorRegionals;

public class RequestOrcamentistaDTO
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataContratacao { get; set; }
    public decimal Salario { get; set; }
    public Endereco Endereco { get; set; }

    public static implicit operator CoordenadorRegional(RequestOrcamentistaDTO dto) =>
    new CoordenadorRegional(dto.Nome, dto.Sobrenome, dto.DataContratacao, dto.Salario, dto.Endereco);
}
