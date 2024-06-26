using MTJM.WebApp.MVC.Models;

namespace MTJM.WebApp.MVC.Services;

public interface IRequestApiService
{
    Task<HttpResponseMessage> Request(string url, Method method, object content = null);
}
