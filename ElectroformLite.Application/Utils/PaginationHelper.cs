using ElectroformLite.Application.Interfaces;

namespace ElectroformLite.Application.Utils;

public static class PaginationHelper
{
    public static PaginatedResponse<T> CreatePaginatedReponse<T>(T pagedData, int pageNumber, int pageSize, int totalPages, int count, IUriService uriService, string route)
    {
        PaginatedResponse<T> respose = new(pagedData, pageNumber, pageSize)
        {
            NextPage =
            pageNumber < totalPages
            ? uriService.GetPageUri(route, pageNumber + 1, pageSize)
            : null,
            PreviousPage =
            pageNumber > 1
            ? uriService.GetPageUri(route, pageNumber - 1, pageSize)
            : null,
            FirstPage = uriService.GetPageUri(route, 1, pageSize),
            LastPage = uriService.GetPageUri(route, totalPages, pageSize),
            TotalPages = totalPages,
            Count = count
        };
        return respose;
    }
}
