using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlRarityRepository : IRarityRepository
{
    private readonly MtgContext _context;
    
    public SqlRarityRepository(MtgContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public IQueryable<Rarity> GetAllRarities()
    {
        return _context.Rarities
            .Select(r => r);
    }
}