using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTJM.API.DTOs.Propostas;
using MTJM.API.Models.Propostas;

namespace MTJM.API.Controllers.Propostas;

[Route("api/[controller]")]
public class PropostaController : BaseController
{
    #region Properties
    private readonly IPropostaRepository _propostaRepository;
    #endregion

    #region Constructors
    public PropostaController(IPropostaRepository propostaRepository)
    {
        _propostaRepository = propostaRepository;
    }
    #endregion

    #region Methods
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(RequestPropostaDTO requestDTO)
    {
        return Ok();
    }
    #endregion
}
