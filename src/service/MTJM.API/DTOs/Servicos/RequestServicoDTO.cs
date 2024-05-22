﻿using MTJM.API.Models.Servicos;

namespace MTJM.API.DTOs.Servicos;

public class RequestServicoDTO
{
    public string Descricao { get; set; }
    public decimal Horas { get; set; }
    public decimal PrecoPorHora { get; set; }
    public string Unidade { get; set; }

    public static implicit operator Servico(RequestServicoDTO dto) => new Servico(dto.Descricao, dto.Horas, dto.PrecoPorHora, dto.Unidade);
}