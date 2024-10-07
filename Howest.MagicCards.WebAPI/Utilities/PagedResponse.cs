namespace Howest.MagicCards.WebAPI.Utilities;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    
    public PagedResponse(T data, int totalRecords,  int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        TotalRecords = totalRecords;
        Data = data;
    }
}