using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface IDeckRepository
{
    Task<Deck> CreateDeck(long cardId);
    
    Task<Deck> GetDeckById(string id);
    
    Task<Deck> UpdateDeck(Deck deck);
    
    Task DeleteDeck(string id);
    
    Task AddCardToDeck(string deckId, long cardId);
    
    Task RemoveCardFromDeck(string deckId, long cardId);
    
    Task ClearAllCardsInDeck(string deckId);
}