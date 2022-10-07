using System.Net;

namespace ElectroformLite.Application.Utils;

public static class HttpUtilities
{
    public static HttpResponseMessage HttpResponseMessageBuilder(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
    {
        return new HttpResponseMessage(statusCode)
        {
            ReasonPhrase = message
        };
    }
}
