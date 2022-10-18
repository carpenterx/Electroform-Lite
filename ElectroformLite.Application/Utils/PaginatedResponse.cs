namespace ElectroformLite.Application.Utils;

public class PaginatedResponse<T>
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; set; }
    public int Count { get; set; }

    public T Data { get; set; }

    public Uri? FirstPage { get; set; }
    public Uri? LastPage { get; set; }

    public Uri? NextPage { get; set; }
    public Uri? PreviousPage { get; set; }

    public PaginatedResponse(T data, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;

        Data = data;
    }
}
