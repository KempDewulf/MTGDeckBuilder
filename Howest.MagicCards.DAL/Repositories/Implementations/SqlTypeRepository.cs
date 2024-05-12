using Howest.MagicCards.DAL.Models;


namespace Howest.MagicCards.DAL.Repositories;

public class SqlTypeRepository : ITypeRepository
{
    private readonly MtgContext _context;

    public SqlTypeRepository(MtgContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IQueryable<Howest.MagicCards.DAL.Models.Type> GetAllTypes()
    {
        return _context.Types.Select(t => t);
    }
}