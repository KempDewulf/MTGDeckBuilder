using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings;

public class SetProfile : Profile
{
    public SetProfile()
    {
        CreateMap<Set, SetDto>();
    }
    
}