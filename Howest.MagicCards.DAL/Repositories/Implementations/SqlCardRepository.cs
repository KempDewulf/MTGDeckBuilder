using Howest.MagicCards.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories;

public class SqlCardRepository : ICardRepository
{
    private readonly MtgContext _context;

    public SqlCardRepository(MtgContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IQueryable<Card> GetAllCards()
    {
        return _context.Cards
            .Select(c => c);
    }

    public Card GetCardById(long id)
    {
        return _context.Cards
            .Include(c => c.Rarity)
            .Include(c => c.Artist)
            .Include(c => c.Set)
            .FirstOrDefault(c => c.Id == id);;
    }
    
    public IQueryable<Card> GetAllCardsByArtistId(int id)
    {
        return _context.Cards
            .Where(c => c.ArtistId == id)
            .Select(c => c);
    }
    
}
