using FluentValidation;
using Kolmeo.Entities.Dtos.Response;


namespace Kolmeo.DataServices.Validators
{
    public interface ICustomValidators
    {
        Task<ApiResult> ValidateAsync<TRequest>(TRequest dto, AbstractValidator<TRequest> validator);
    }
}
