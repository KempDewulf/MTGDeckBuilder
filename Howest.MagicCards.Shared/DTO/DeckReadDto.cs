namespace Howest.MagicCards.Shared.DTO;

public class DeckReadDto
{
    public string Id { get; set; }

    public IEnumerable<CardInDeckReadDto> Cards { get; set; }
}