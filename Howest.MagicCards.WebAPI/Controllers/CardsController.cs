using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.Shared.Filters;
using Howest.MagicCards.WebAPI.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/cards")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    
    public CardsController(ICardRepository cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;

    }

    [HttpGet("all")]
    public ActionResult<PagedResponse<IEnumerable<CardReadDto>>> GetCards([FromQuery] CardFilter cardFilter)
    {
        IQueryable<Card> cards = _cardRepository.GetAllCards();
        cards = FilterUtility.ToFilteredList(cards, cardFilter.ArtistName, cardFilter.RarityName, cardFilter.SetName,
            cardFilter.CardName, cardFilter.CardText, cardFilter.CardType);
        return Ok(new PagedResponse<IEnumerable<CardReadDto>>(
                    cards.OrderBy(c => c.Id)
                        .Skip((cardFilter.PageNumber - 1) * cardFilter.PageSize)
                        .Take(cardFilter.PageSize)
                        .ProjectTo<CardReadDto>(_mapper.ConfigurationProvider)
                        .ToList(),
                _cardRepository.GetAllCards().Count(),
                cardFilter.PageNumber,
                cardFilter.PageSize

            )
        );
    }
    
    
    
}
