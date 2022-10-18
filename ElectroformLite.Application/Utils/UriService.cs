using ElectroformLite.Application.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace ElectroformLite.Application.Utils
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(string route, int pageNumber, int pageSize)
        {
            var enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(enpointUri.ToString(), "pageNumber", pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
