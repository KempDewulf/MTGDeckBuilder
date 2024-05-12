using GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;

namespace Howest.MagicCards.GraphQL.Types;

public class ArtistType : ObjectGraphType<Artist>
{
    public ArtistType(ICardRepository cardRepository)
    {
        Name = "Artist";
        Field(a => a.Id, type: typeof(LongGraphType)).Description("The id of the artist.");
        Field(a => a.FullName, type: typeof(StringGraphType)).Description("The full name of the artist.");
        Field<ListGraphType<CardType>>(
            "Cards",
            resolve: context => cardRepository.GetAllCardsByArtistId((int)context.Source.Id).Take(10).ToList()
        );
    }
    
}