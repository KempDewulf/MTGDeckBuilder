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
    
    public Task<Deck> CreateDeck()
    {
        var newDeck = new Deck();
        
        _deckCollection.InsertOne(newDeck);

        return Task.FromResult(newDeck);
    }

    public Task<Deck> GetDeckById(string id)
    {
        var deck = _deckCollection.Find(deck => deck.Id == ObjectId.Parse(id)).FirstOrDefault();
        
        return Task.FromResult(deck);
    }

    public Task<Deck> UpdateDeck(Deck deck)
    {
        _deckCollection.ReplaceOne(d => d.Id == deck.Id, deck);
        
        return Task.FromResult(deck);
    }

    public Task DeleteDeck(string id)
    {
        _deckCollection.DeleteOne(deck => deck.Id == ObjectId.Parse(id));
        
        return Task.CompletedTask;
    }
}