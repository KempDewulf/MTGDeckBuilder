
using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using FluentUtils.MinimalApis.EndpointDefinitions;
using Howest.MagicCards.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
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

        app.MapGet($"{_commonPrefix}/{{id}}", GetDeckById)
            .Produces<DeckReadDto>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");

        app.MapPut($"{_commonPrefix}/{{id}}", UpdateDeck)
            .Accepts<DeckWriteDto>("application/json")
            .Produces<DeckReadDto>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");

        app.MapDelete($"{_commonPrefix}/{{id}}", DeleteDeck)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");
        
        app.MapPost($"{_commonPrefix}/{{id}}/cards", AddCardToDeck)
            .Accepts<CardInDeckWriteDto>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");

        app.MapDelete($"{_commonPrefix}/{{id}}/cards", RemoveCardFromDeck)
            .Accepts<CardInDeckWriteDto>("application/json")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Decks");
            
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IDeckRepository, MdbDeckRepository>();
    }

    private async Task<IResult> AddDeck(IDeckRepository repository, IMapper mapper, CardInDeckWriteDto cardInDeck)
    {
        var deck = await repository.CreateDeck(cardInDeck.CardId);

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
    
    private async Task<IResult> AddCardToDeck([FromServices] IDeckRepository repository, [FromRoute] string id, [FromBody] CardInDeckWriteDto cardInDeck)
    {
        await repository.AddCardToDeck(id, cardInDeck.CardId);
        return Results.NoContent();
    }

    private async Task<IResult> RemoveCardFromDeck([FromServices] IDeckRepository repository, [FromRoute] string id, [FromBody] CardInDeckWriteDto cardInDeck)
    {
        await repository.RemoveCardFromDeck(id, cardInDeck.CardId);
        return Results.NoContent();
    }
}
