using Howest.MagicCards.DAL.Models;

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
        return _context.Cards;
    }
    
}