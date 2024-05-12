using GraphQL;
using GraphQL.Types;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.Types;
using Howest.MagicCards.Shared.DTO;
using SharpCompress.Crypto;

namespace Howest.MagicCards.GraphQL.Queries;

public class RootQuery : ObjectGraphType
{
    public RootQuery(ICardRepository cardRepository)
    {
        Field<ListGraphType<CardType>>(
            "Cards",
            Description = "Get all cards",
            
            resolve: context => cardRepository.GetAllCards().Take(1).ToList()
        );

        Field<ListGraphType<CardType>>(
            "Filter",
            "Get all cards",
            arguments: new QueryArguments
            {
                new QueryArgument<IntGraphType> { Name = "Toughness"},
                new QueryArgument<IntGraphType> { Name = "Power"}
            },
            resolve: context =>
            {
                string toughness = context.GetArgument<string>("Toughness");
                string power = context.GetArgument<string>("Power");


                return cardRepository.GetAllCards().Take(1).ToList();
            }
        );
    }
    
}