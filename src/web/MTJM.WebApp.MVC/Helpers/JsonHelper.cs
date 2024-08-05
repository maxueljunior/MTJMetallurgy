using MTJM.WebApp.MVC.Models;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace MTJM.WebApp.MVC.Helpers;

public static class JsonHelper
{
    public static T JsonToObject<T>(dynamic result)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyFields = true,
        };

        return JsonSerializer.Deserialize<T>(result, options);
    }
}
