using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
using Howest.MagicCards.WebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Howest.MagicCards.WebAPI.Controllers;

[Route("api/types")]
[ApiController]
public class TypesController : ControllerBase
{
    private readonly ITypeRepository _typeRepository;
    private readonly IMapper _mapper;
    
    public TypesController(ITypeRepository typeRepository, IMapper mapper)
    {
        _typeRepository = typeRepository;
        _mapper = mapper;
    }
    
    [HttpGet("all")]
    public ActionResult<Response<IEnumerable<TypeDto>>> GetTypes()
    {
        return Ok(new Response<IEnumerable<TypeDto>>(
            _typeRepository
                .GetAllTypes()
                .ProjectTo<TypeDto>(_mapper.ConfigurationProvider)
                .ToList())
        );
    }
}