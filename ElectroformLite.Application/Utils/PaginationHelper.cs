using ElectroformLite.Application.Interfaces;

namespace ElectroformLite.Application.Utils;

public static class PaginationHelper
{
    public static PaginatedResponse<T> CreatePaginatedReponse<T>(T pagedData, int pageNumber, int pageSize, int totalRecords, IUriService uriService, string route)
    {
        var respose = new PaginatedResponse<T>(pagedData, pageNumber, pageSize);
        var totalPages = ((double)totalRecords / (double)pageSize);
        int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        respose.NextPage =
            pageNumber >= 1 && pageNumber < roundedTotalPages
            ? uriService.GetPageUri(route, pageNumber + 1, pageSize)
            : null;
        respose.PreviousPage =
            pageNumber - 1 >= 1 && pageNumber <= roundedTotalPages
            ? uriService.GetPageUri(route, pageNumber - 1, pageSize)
            : null;
        respose.FirstPage = uriService.GetPageUri(route, 1, pageSize);
        respose.LastPage = uriService.GetPageUri(route, roundedTotalPages, pageSize);
        respose.TotalPages = roundedTotalPages;
        respose.TotalRecords = totalRecords;
        return respose;
    }
}
