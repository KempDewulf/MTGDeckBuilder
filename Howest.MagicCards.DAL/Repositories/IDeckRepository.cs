using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface IDeckRepository
{
    Task<Deck> CreateDeck();
    
    Task<Deck> GetDeckById(string id);
    
    Task<Deck> UpdateDeck(Deck deck);
    
    Task DeleteDeck(string id);
}