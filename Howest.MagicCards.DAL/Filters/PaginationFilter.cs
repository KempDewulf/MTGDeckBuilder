namespace Howest.MagicCards.DAL.Filters;

public class PaginationFilter
{
    const int MaxPageSize = 150;
    
    private int _pageSize = MaxPageSize;
    private int _pageNumber = 1;
    
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value is > MaxPageSize or < 1 ? MaxPageSize : value;
    }
}