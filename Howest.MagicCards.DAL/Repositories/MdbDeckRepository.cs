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
    
    public async Task<Deck> CreateDeck()
    {
        var newDeck = new Deck();
        
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
}