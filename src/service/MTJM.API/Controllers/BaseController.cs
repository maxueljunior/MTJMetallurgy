using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTJM.API.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    #region Properties
    protected ICollection<string> Errors = new List<string>();
    #endregion

    #region Methods
    protected IActionResult CustomResponse(object result = null)
    {
        if (IsOperacaoValida())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", Errors.ToArray() }
        }));
    }

    protected bool IsOperacaoValida()
    {
        return !Errors.Any();
    }

    protected IActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach(var error in validationResult.Errors)
        {
            AdicionaErros(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected IActionResult CustomResponse(List<string> errors)
    {
        foreach (var error in errors)
        {
            AdicionaErros(error);
        }

        return CustomResponse();
    }

    protected void AdicionaErros(string erro)
    {
        Errors.Add(erro);
    }
    #endregion
}
