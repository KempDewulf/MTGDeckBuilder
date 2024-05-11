
using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using FluentUtils.MinimalApis.EndpointDefinitions;
using Howest.MagicCards.Shared.DTO;
using MongoDB.Bson;

namespace Howest.MagicCards.MinimalAPI.EndPointDefinitions;

public class DecksEndPoints : IEndpointDefinition
{
    const string _commonPrefix = "/api/decks";

    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost($"{_commonPrefix}", AddDeck)
            .Accepts<DeckWriteDto>("application/json")
            .Produces<DeckReadDto>(StatusCodes.Status201Created)
            .WithTags("Decks");

        app.MapGet($"{_commonPrefix}/{{id:string}}", GetDeckById)
            .Produces<DeckReadDto>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");

        app.MapPut($"{_commonPrefix}/{{id:string}}", UpdateDeck)
            .Accepts<DeckWriteDto>("application/json")
            .Produces<DeckReadDto>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");

        app.MapDelete($"{_commonPrefix}/{{id:string}}", DeleteDeck)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IDeckRepository, MdbDeckRepository>();
    }

    private async Task<IResult> AddDeck(IDeckRepository repository, IMapper mapper, DeckWriteDto newDeck)
    {
        var deck = mapper.Map<Deck>(newDeck);
        await repository.CreateDeck(deck);

        var deckReadDto = mapper.Map<DeckReadDto>(deck);

        return Results.Created($"{_commonPrefix}/{deck.Id}", deckReadDto);
    }

    private async Task<IResult> GetDeckById(IDeckRepository repository, IMapper mapper, string id)
    {
        var deck = await repository.GetDeckById(id);

        if (deck == null)
        {
            return Results.NotFound($"Deck not found");
        }

        var deckReadDto = mapper.Map<DeckReadDto>(deck);

        return Results.Ok(deckReadDto);
    }

    private async Task<IResult> UpdateDeck(IDeckRepository repository, IMapper mapper, string id,
        DeckWriteDto deckWriteDto)
    {
        var deck = mapper.Map<Deck>(deckWriteDto);
        deck.Id = ObjectId.Parse(id);

        await repository.UpdateDeck(deck);

        var deckReadDto = mapper.Map<DeckReadDto>(deck);

        return Results.Ok(deckReadDto);
    }

    private async Task<IResult> DeleteDeck(IDeckRepository repository, string id)
    {
        await repository.DeleteDeck(id);

        return Results.NoContent();
    }
}
