using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface ICardRepository
{
    IQueryable<Card>  GetAllCards();
    
    Card GetCardById(long id);
    
    IQueryable<Card> GetAllCardsByArtistId(int id);
    
}
