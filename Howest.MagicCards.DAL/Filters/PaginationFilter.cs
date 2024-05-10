namespace Howest.MagicCards.DAL.Filters;

public class PaginationFilter
{
    const int maxPageSize = 150;
    
    private int _pageSize = maxPageSize;
    private int _pageNumber = 1;
    
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value is > maxPageSize or < 1 ? maxPageSize : value;
    }
}