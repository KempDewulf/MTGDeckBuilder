using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories;

public interface IArtistRepository
{
    IQueryable<Artist> GetAllArtists();
    
    IQueryable<Artist> GetArtistFromCardId(int cardId);
}