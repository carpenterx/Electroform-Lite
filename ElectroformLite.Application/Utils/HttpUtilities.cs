using System.Net;

namespace ElectroformLite.Application.Utils;

public static class HttpUtilities
{
    public static HttpResponseMessage HttpResponseMessageBuilder(string message)
    {
        return new HttpResponseMessage(HttpStatusCode.NotFound)
        {
            ReasonPhrase = message
        };
    }
}
