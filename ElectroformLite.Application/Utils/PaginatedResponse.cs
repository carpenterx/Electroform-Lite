namespace ElectroformLite.Application.Utils;

public class PaginatedResponse<T>
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }

    public T Data { get; set; }

    public PaginatedResponse()
    {

    }

    public PaginatedResponse(T data, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;

        Data = data;
    }
}
