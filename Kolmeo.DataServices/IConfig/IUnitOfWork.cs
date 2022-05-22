using FluentValidation;
using Kolmeo.DataServices.IRepositories;

namespace Kolmeo.DataServices.IConfig
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        Task CompleteAsync();
    }
}
