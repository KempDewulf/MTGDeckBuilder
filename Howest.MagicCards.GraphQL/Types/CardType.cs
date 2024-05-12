using GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.Types;

public class CardType : ObjectGraphType<Card>
{
    public CardType()
    {
        Name = "Card";
        Field(c => c.Id, type: typeof(LongGraphType)).Description("The unique identifier of the card.");
        Field(c => c.Name, type: typeof(StringGraphType)).Description("The name of the card.");
        Field(c => c.OriginalImageUrl, type: typeof(StringGraphType)).Description("The URL of the image of the card.");
        Field(c => c.RarityCode, type: typeof(StringGraphType)).Description("The rarity of the card.");
        Field(c => c.SetCode, type: typeof(StringGraphType)).Description("The name of the set the card belongs to.");
        Field(c => c.OriginalType, type: typeof(StringGraphType)).Description("The type of the card.");
        Field(c => c.ArtistId, type: typeof(StringGraphType)).Description("The name of the artist who created the card.");
    }
    
}