
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/cards")]
[ApiController]
public class CardsController : Controller
{
    private readonly ICardRepository _cardRepository;
    
    
    public CardsController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    
    [HttpGet]
    public OkObjectResult First()
    {
        Card firstCard = _cardRepository.GetAllCards().FirstOrDefault();
        return Ok(firstCard);
    }
    
}