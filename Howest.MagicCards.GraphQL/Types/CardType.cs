using GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.GraphQL.Types;

public class CardType : ObjectGraphType<Card>
{
    public CardType(IArtistRepository artistRepository)
    {
        Name = "Card";
        Field(c => c.Id, type: typeof(LongGraphType)).Description("Id of the card.");
        Field(c => c.Name, type: typeof(StringGraphType)).Description("Name of the card.");
        Field(c => c.OriginalImageUrl, type: typeof(StringGraphType)).Description("Image URL of the card.");
        Field(c => c.RarityCode, type: typeof(StringGraphType)).Description("The card rarity.");
        Field(c => c.SetCode, type: typeof(StringGraphType)).Description("The card set code.");
        Field(c => c.OriginalType, type: typeof(StringGraphType)).Description("The card type.");
        Field<ArtistType>(
            "Artist",
            resolve: c => artistRepository.GetArtistFromCardId((int) c.Source.Id)
        );
    }
    
}