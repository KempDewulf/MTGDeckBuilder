﻿namespace Howest.MagicCards.Shared.Filters;

public class CardFilter: PaginationFilter
{
    public string ArtistName { get; set; } = "";
    public string SetName { get; set; } = "";
    public string RarityName { get; set; } = "";
    public string CardName { get; set; } = "";
    public string CardType { get; set; } = "";
    public string CardText { get; set; } = "";
}