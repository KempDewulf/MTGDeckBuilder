using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlSetRepository : ISetRepository
{
    private readonly MtgContext _context;
    
    public SqlSetRepository(MtgContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public IQueryable<Set> GetAllSets()
    {
        return _context.Sets
            .Select(s => s);
    }
}