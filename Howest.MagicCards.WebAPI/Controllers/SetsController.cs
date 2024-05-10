using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/sets")]
[ApiController]
public class SetsController : ControllerBase
{
    private readonly ISetRepository _setRepository;
    private readonly IMapper _mapper;
    
    public SetsController(ISetRepository setRepository, IMapper mapper)
    {
        _setRepository = setRepository;
        _mapper = mapper;
    }
    
    [HttpGet("all")]
    public ActionResult<Response<IEnumerable<SetDto>>> GetSets()
    {
        return Ok(
            _setRepository
                .GetAllSets()
                .ProjectTo<SetDto>(_mapper.ConfigurationProvider)
                .ToList());
    }
}