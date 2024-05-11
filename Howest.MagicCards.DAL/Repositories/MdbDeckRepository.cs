using Howest.MagicCards.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Howest.MagicCards.DAL.Repositories;

public class MdbDeckRepository : IDeckRepository
{
    private readonly IMongoCollection<Deck> _deckCollection;
    
    public MdbDeckRepository(MongoDbContext context)
    {
        var mongoClient = new MongoClient(context.ConnectionString);
        
        var database = mongoClient.GetDatabase(context.DatabaseName);
        
        _deckCollection = database.GetCollection<Deck>(context.CollectionName);
    }
    
    public async Task<Deck> CreateDeck(Deck newDeck)
    {
        await _deckCollection.InsertOneAsync(newDeck);

        return newDeck;
    }

    public async Task<Deck> GetDeckById(string id)
    {
        var deck = await _deckCollection.Find(deck => deck.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        
        return deck;
    }

    public async Task<Deck> UpdateDeck(Deck deck)
    {
        await _deckCollection.ReplaceOneAsync(d => d.Id == deck.Id, deck);
        
        return deck;
    }

    public async Task DeleteDeck(string id)
    {
        await _deckCollection.DeleteOneAsync(deck => deck.Id == ObjectId.Parse(id));
    }

    public async Task AddCardToDeck(string deckId, long cardId)
    {
        var deck = await GetDeckById(deckId);
        var card = deck.Cards.FirstOrDefault(c => c.CardId == cardId);
        if (card == null)
        {
            deck.Cards = deck.Cards.Append(new CardInDeck
            {
                CardId = cardId,
                Quantity = 1 
                
            });
        }
        else
        {
            card.Quantity++;
        }
    }
    
    public async Task RemoveCardFromDeck(string deckId, long cardId)
    {
        var deck = await GetDeckById(deckId);
        var card = deck.Cards.FirstOrDefault(c => c.CardId == cardId);
        if (card != null)
        {
            if (card.Quantity > 1)
            {
                card.Quantity--;
            }
            else
            {
                deck.Cards = deck.Cards.Where(c => c.CardId != cardId);
            }
        }
    }
    
    
}