namespace ElectroformLite.Application.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(string route, int pageNumber, int pageSize);
    }
}
