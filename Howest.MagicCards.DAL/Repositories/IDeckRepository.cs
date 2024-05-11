using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface IDeckRepository
{
    Task<Deck> CreateDeck(Deck deck);
    
    IQueryable<Deck> GetDeckById(string id);
    
    Task<Deck> UpdateDeck(Deck deck);
    
    Task DeleteDeck(string id);
}