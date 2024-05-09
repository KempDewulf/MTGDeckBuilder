using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/cards")]
[ApiController]
public class CardsController : Controller
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    
    public CardsController(ICardRepository cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;

    }
    
    [HttpGet("first")]
    public ActionResult<CardDto> First()
    {
        Card firstCard = _cardRepository.GetAllCards().FirstOrDefault();
        if (firstCard == null) return NotFound();

        CardDto dto = _mapper.Map<CardDto>(firstCard);

        return Ok(dto);
    }

    [HttpGet("first150")]
    public ActionResult<List<CardDto>> First150()
    {
        List<Card> first150Cards = _cardRepository.GetAllCards().Take(150).ToList();
        List<CardDto> dtos = _mapper.Map<List<CardDto>>(first150Cards);

        return Ok(dtos);
    }
    
}
