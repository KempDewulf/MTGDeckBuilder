using AutoMapper;
using AutoMapper.QueryableExtensions;
using Howest.MagicCards.DAL.Filters;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.DTO;
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
    public ActionResult<PagedResponse<IEnumerable<CardDto>>> GetCards([FromQuery] PaginationFilter paginationFilter)
    {
        var query = _cardRepository.GetAllCards();
        var totalRecords = query.Count();
        var totalPages = (totalRecords + paginationFilter.PageSize - 1) / paginationFilter.PageSize;

        var pagedData = query
            .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
            .Take(paginationFilter.PageSize)
            .ProjectTo<CardDto>(_mapper.ConfigurationProvider)
            .ToList();

        return Ok(new PagedResponse<IEnumerable<CardDto>>(pagedData, paginationFilter.PageNumber, paginationFilter.PageSize)
        {
            TotalRecords = totalRecords,
            TotalPages = totalPages
        });
    }
    
}
