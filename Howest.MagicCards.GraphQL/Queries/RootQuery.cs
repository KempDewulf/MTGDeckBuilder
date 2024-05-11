using GraphQL.Types;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.GraphQL.Types;
using SharpCompress.Crypto;

namespace Howest.MagicCards.GraphQL.Queries;

public class RootQuery : ObjectGraphType
{
    public RootQuery(ICardRepository cardRepository)
    {
        Field<ListGraphType<CardType>>("cards")
            .Resolve(context => cardRepository.GetAllCards());
    }
    
}