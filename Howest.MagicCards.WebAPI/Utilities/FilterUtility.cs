using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.WebAPI.Utilities;

public class FilterUtility
{
    public static IQueryable<Card> ToFilteredList(IQueryable<Card> cards, string artistName, string rarityName, string setName, string cardName, string cardText, string cardType)
    {
        return cards.Where(card => card.Artist.FullName.Contains(artistName)
                                   && card.Rarity.Name.Contains(rarityName)
                                   && card.Set.Name.Contains(setName)
                                   && card.Name.Contains(cardName)
                                   && card.Text.Contains(cardText)
                                   && card.Type.Contains(cardType)
        );
    }
}