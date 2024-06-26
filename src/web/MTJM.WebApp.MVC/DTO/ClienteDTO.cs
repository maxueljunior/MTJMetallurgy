﻿
namespace MTJM.WebApp.MVC.DTO;

public class ClienteDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public EnderecoDTO Endereco { get; set; }
    public bool Ativo { get; set; }
    public int? CoordenadorRegionalId { get; set; }
}