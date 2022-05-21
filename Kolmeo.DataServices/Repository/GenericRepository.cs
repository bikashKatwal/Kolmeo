using Kolmeo.DataServices.Data;
using Kolmeo.DataServices.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kolmeo.DataServices.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();

        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            return await dbSet.FindAsync(Id);
        }
    }
}
