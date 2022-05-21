namespace Kolmeo.DataServices.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid Id);
        Task<bool> Add(T entity);
    }
}
