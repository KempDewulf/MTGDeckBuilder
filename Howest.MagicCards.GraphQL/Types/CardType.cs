using GraphQL.Types;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.Types;

public class CardType : ObjectGraphType<CardReadDto>
{
    public CardType()
    {
        Field(c => c.Id, type: typeof(IdGraphType)).Description("The unique identifier of the card.");
        Field(c => c.Name).Description("The name of the card.");
        Field(c => c.ImageUrl).Description("The name of the artist who created the card.");
        Field(c => c.Rarity).Description("The name of the set the card belongs to.");
        Field(c => c.Artist).Description("The rarity of the card.");
        Field(c => c.Set).Description("The type of the card.");
    }
    
}