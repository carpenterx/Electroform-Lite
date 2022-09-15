using System.Net;
using System.Web.Http;

namespace ElectroformLite.Application.Exceptions;

public class NotFoundHttpResponseException : HttpResponseException
{
    public NotFoundHttpResponseException(HttpStatusCode statusCode) : base(statusCode)
    {
    }

    public NotFoundHttpResponseException(HttpResponseMessage response) : base(response)
    {
    }
}
