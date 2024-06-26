
using MTJM.WebApp.MVC.Helpers;
using System.Net.Http.Headers;

namespace MTJM.WebApp.MVC.Handler;

public class CustomHttpClientHandler : DelegatingHandler
{
    private readonly IClaimsHelpers _claimsHelpers;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomHttpClientHandler(IClaimsHelpers claimsHelpers,
        IHttpContextAccessor httpContextAccessor)
    {
        _claimsHelpers = claimsHelpers;
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _claimsHelpers.GetToken();
        
        if(!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
