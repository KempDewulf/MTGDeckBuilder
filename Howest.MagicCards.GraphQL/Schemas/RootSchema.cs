using GraphQL.Types;
using Howest.MagicCards.GraphQL.Queries;

namespace Howest.MagicCards.GraphQL.Schemas;

public class RootSchema : Schema
{
    public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<RootQuery>();
    }
}