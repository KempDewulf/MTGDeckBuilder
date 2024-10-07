namespace Howest.MagicCards.DAL.Repositories;

public interface ITypeRepository
{
    IQueryable<Howest.MagicCards.DAL.Models.Type> GetAllTypes();
}