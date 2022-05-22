using Kolmeo.DataServices.Data;
using Kolmeo.DataServices.IRepositories;
using Kolmeo.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace Kolmeo.DataServices.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductByName(string ProductName)
        {
            return await dbSet.Where(x => x.Name.ToLower() == ProductName.ToLower()).ToListAsync();
        }
    }
}
