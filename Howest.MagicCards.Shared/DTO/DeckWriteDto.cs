
namespace Howest.MagicCards.Shared.DTO;

public class DeckWriteDto
{
    public string Id { get; set; }

    public IEnumerable<CardInDeckWriteDto> Cards { get; set; }
}