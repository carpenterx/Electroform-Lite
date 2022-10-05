namespace ElectroformLite.Application.Utils;

public class PaginationValidator
{
    public int PageNumber { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }

    public static readonly int DEFAULT_PAGE_NUMBER = 1;
    public static readonly int DEFAULT_PAGE_SIZE = 4;
    
    public PaginationValidator(int pageNumber, int pageSize, int totalCount)
    {
        if (pageSize >= 1 && pageSize <= DEFAULT_PAGE_SIZE)
        {
            PageSize = pageSize;
        }
        else
        {
            PageSize = DEFAULT_PAGE_SIZE;
        }
        TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
        if (pageNumber >= 1 && pageNumber <= TotalPages)
        {
            PageNumber = pageNumber;
        }
        else
        {
            PageNumber = DEFAULT_PAGE_NUMBER;
        }
        
    }
}
