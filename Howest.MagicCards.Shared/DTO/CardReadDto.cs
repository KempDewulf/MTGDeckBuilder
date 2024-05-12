namespace Howest.MagicCards.Shared.DTO;

public class CardReadDto
{
    public long Id { get; set; } = 0;
    
    public string Name { get; set; } = "";
    
    public string ImageUrl { get; set; } = "";
    
    public string Rarity { get; set; } = "";
    
    public string Artist { get; set; } = "";
    
    public string Set { get; set; } = "";
    
    public string Type { get; set; } = "";
    
}