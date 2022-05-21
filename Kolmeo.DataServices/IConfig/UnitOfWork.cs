using Kolmeo.DataServices.Data;
using Kolmeo.DataServices.IRepositories;
using Kolmeo.DataServices.Repository;

namespace Kolmeo.DataServices.IConfig
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
