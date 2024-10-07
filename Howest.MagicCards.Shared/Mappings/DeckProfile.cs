using AutoMapper;

namespace Howest.MagicCards.Shared.Mappings;

public class DeckProfile : Profile
{
    public DeckProfile()
    {
        CreateMap<DAL.Models.Deck, DTO.DeckReadDto>();
        CreateMap<DAL.Models.CardInDeck, DTO.CardInDeckReadDto>();
        CreateMap<DTO.CardInDeckWriteDto, DAL.Models.CardInDeck>();
        CreateMap<DTO.DeckWriteDto, DAL.Models.Deck>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
    
}