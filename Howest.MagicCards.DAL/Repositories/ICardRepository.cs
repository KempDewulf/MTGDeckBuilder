using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface ICardRepository
{
    IQueryable<Card>  GetAllCards();
    
    IQueryable<Card> GetAllCardsByArtistId(int id);
    
}
