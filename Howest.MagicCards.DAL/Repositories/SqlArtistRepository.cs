using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlArtistRepository : IArtistRepository
{
    private readonly MtgContext _context;
    
    public SqlArtistRepository(MtgContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public IQueryable<Artist> GetAllArtists()
    {
        return _context.Artists
            .Select(a => a);   
    }

    public IQueryable<Artist> GetArtistFromCardId(int cardId)
    {
        return _context.Artists
            .Where(a => a.Cards.Any(c => c.Id == cardId))
            .Select(a => a);
    }
}