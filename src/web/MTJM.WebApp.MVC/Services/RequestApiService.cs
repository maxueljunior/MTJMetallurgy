using MTJM.WebApp.MVC.Models;
using System.Text;
using System.Text.Json;

namespace MTJM.WebApp.MVC.Services;

public class RequestApiService : IRequestApiService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RequestApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpResponseMessage> Request(string url, Method method, object content = null)
    {
        var client = _httpClientFactory.CreateClient("ApiClient");

        StringContent stringContent = new StringContent("");
        HttpResponseMessage response = new HttpResponseMessage();

        if(content is not null)
            stringContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

        switch (method)
        {
            case Method.GET:
                response = await client.GetAsync(url);
                break;

            case Method.POST:
                response = await client.PostAsync(url, stringContent);
                break;

            case Method.PUT:
                response = await client.PutAsync(url, stringContent);
                break;

            case Method.DELETE:
                response = await client.DeleteAsync(url);
                break;
        }

        return response;
    }
}
