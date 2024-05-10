using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Filters;

public class CardFilter: PaginationFilter
{
    public string ArtistName { get; set; } = "";
}