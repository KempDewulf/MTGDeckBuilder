using GraphQL;
using GraphQL.Types;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.Types;
using Howest.MagicCards.Shared.DTO;
using SharpCompress.Crypto;
using CardType = Howest.MagicCards.GraphQL.Types.CardType;

namespace Howest.MagicCards.GraphQL.Queries;

public class RootQuery : ObjectGraphType
{
    public RootQuery(ICardRepository cardRepository, IArtistRepository artistRepository)
    {
        Field<ListGraphType<CardType>>(
            "Cards",
            Description = "Get all cards",
            arguments:
            [
                new QueryArgument<IntGraphType> { Name = "limit", DefaultValue = null },
                new QueryArgument<StringGraphType> { Name = "Toughness", DefaultValue = null },
                new QueryArgument<StringGraphType> { Name = "Power", DefaultValue = null }
            ],
            resolve: context =>
            {
                var cards = cardRepository.GetAllCards().AsQueryable();

                var toughness = context.GetArgument<string>("Toughness");
                cards = ApplyToughnessFilter(cards, toughness);

                var power = context.GetArgument<string>("Power");
                cards = ApplyPowerFilter(cards, power);
                
                var maxCards = context.GetArgument<int?>("limit");
                cards = ApplyLimit(cards, maxCards);

                return cards.ToList();
            }
        );
        
        Field<ListGraphType<ArtistType>>(
            "Artists",
            Description = "Get all artists",
            arguments: new QueryArguments
            {
                new QueryArgument<IntGraphType> {Name = "limit", DefaultValue = null}
            },
            resolve: context =>
            {
                var artists = artistRepository.GetAllArtists().AsQueryable();
                
                var maxArtists = context.GetArgument<int?>("limit");
                artists = ApplyLimit(artists, maxArtists);
                
                return artists.ToList();
            }
        );
        
        Field<ArtistType>(
            "Artist",
            Description = "Get an artist by id",
            arguments: new QueryArguments
            {
                new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "artistId"}
            },
            resolve: context =>
            {
                int artistId = context.GetArgument<int>("artistId");
                
                return artistRepository.GetArtistById(artistId);
            }
        );
        
    }
    
    private static IQueryable<T> ApplyLimit<T>(IQueryable<T> items, int? limit)
    {
        return limit.HasValue ? items.Take(limit.Value) : items;
    }

    private static IQueryable<Card> ApplyToughnessFilter(IQueryable<Card> cards, string toughness)
    {
        return toughness != null ? cards.Where(c => c.Toughness == toughness) : cards;
    }

    private static IQueryable<Card> ApplyPowerFilter(IQueryable<Card> cards, string power)
    {
        return power != null ? cards.Where(c => c.Power == power) : cards;
    }
    
}