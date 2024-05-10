using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/rarities")]
[ApiController]
public class RarityController : ControllerBase
{
    private readonly IRarityRepository _rarityRepository;
    private readonly IMapper _mapper;
    
    public RarityController(IRarityRepository rarityRepository, IMapper mapper)
    {
        _rarityRepository = rarityRepository;
        _mapper = mapper;
    }
    
    [HttpGet("all")]
    public ActionResult<PagedResponse<IEnumerable<RarityDto>>> GetRarities()
    {
        return Ok(
            _rarityRepository
                .GetAllRarities()
                .ProjectTo<RarityDto>(_mapper.ConfigurationProvider)
                .ToList());
    }
    
}