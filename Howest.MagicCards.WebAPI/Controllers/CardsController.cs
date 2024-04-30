
using Howest.MagicCards.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

public class CardsController : Controller
{
    private readonly MtgContext _db;
    
    public CardsController()
    {
        _db = new MtgContext();
    }
}