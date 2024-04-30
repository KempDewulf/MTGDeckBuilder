
using Howest.MagicCards.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/cards")]
[ApiController]
public class CardsController : Controller
{
    private readonly MtgContext _db;
    
    public CardsController(MtgContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public OkObjectResult First()
    {
        Card firtsCard = _db.Cards.FirstOrDefault();
        return Ok(firtsCard);
    }
    
}