using MongoDB.Bson;

namespace Howest.MagicCards.DAL.Models;

public partial class Deck
{
    public Deck()
    {
        Cards = new List<CardInDeck>();
    }
    public ObjectId Id { get; set; }
    
    public IEnumerable<CardInDeck> Cards { get; set; }
    
    public void AddCard(CardInDeck card)
    {
        ((List<CardInDeck>)Cards).Add(card);
    }

    public void RemoveCard(CardInDeck card)
    {
        ((List<CardInDeck>)Cards).Remove(card);
    }
}