using System.Web.Http;

namespace ElectroformLite.Application.Exceptions;

public class CantDeleteHttpResponseException : HttpResponseException
{
    public CantDeleteHttpResponseException(HttpResponseMessage response) : base(response)
    {
    }
}
