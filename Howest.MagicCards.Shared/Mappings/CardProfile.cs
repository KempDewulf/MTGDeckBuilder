using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<Card, CardReadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.OriginalImageUrl))
            .ForMember(dest => dest.Rarity, opt => opt.MapFrom(src => src.Rarity.Name))
            .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist.FullName))
            .ForMember(dest => dest.Set, opt => opt.MapFrom(src => src.Set.Name));
    }
}