using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.Context;
using MTJM.API.DTOs.Servicos;
using MTJM.API.Models.Servicos;

namespace MTJM.API.Controllers.Servicos;

[Route("api/[controller]")]
[ApiController]
public class ServicoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(CreateServicoDTO servicoDTO)
    {
        Servico servico = servicoDTO;

        if(servico.ValidationResult is not null) return BadRequest(servico.ValidationResult.Errors);

        await _context.Servicos.AddAsync(servico);

        await _context.SaveChangesAsync();

        return Ok(servico);
    }
}
