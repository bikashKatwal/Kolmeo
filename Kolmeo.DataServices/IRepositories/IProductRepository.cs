using Kolmeo.Entities.DbSet;

namespace Kolmeo.DataServices.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByName(string name);
    }
}
