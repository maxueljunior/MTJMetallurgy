using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MTJM.API.Attributes;

public class ClaimsAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _claimType;
    private readonly string _claimValue;

    public ClaimsAuthorizeAttribute(string claimType, string claimValue)
    {
        _claimType = claimType;
        _claimValue = claimValue;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if(!user.Identity.IsAuthenticated )
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        
        // TO DO Verificar se o usuário e Admin e caso ele for ele passa direto e não precisa deixar
        // passar para a validação de baixo....
        // Também olhar a possibilidade de também utilizar Roles para fazer essa verificação para que isso
        // Fique mais facil do que ficar utilizando claims
        
        //var claim = user.Claims.FirstOrDefault(c => c.Type == _claimType && c.Value.Contains(_claimValue));
        var claim = user.Claims.FirstOrDefault(c => _claimType.Contains(c.Type) && c.Value.Contains(_claimValue));

        if (claim is null)
            context.Result = new ForbidResult();
    }
}
