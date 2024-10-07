using AutoMapper;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings;

public class TypeProfile : Profile
{
    public TypeProfile()
    {
        CreateMap<Howest.MagicCards.DAL.Models.Type, TypeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
    }
}