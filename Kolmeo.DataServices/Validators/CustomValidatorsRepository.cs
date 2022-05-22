using FluentValidation;
using Kolmeo.Entities.Dtos.Response;

namespace Kolmeo.DataServices.Validators
{
    public class CustomValidatorsRepository : ICustomValidators
    {
        public async Task<ApiResult> ValidateAsync<TRequest>(TRequest dto, AbstractValidator<TRequest> validator)
        {
            if (dto == null)
            {
                throw new ArgumentNullException();
            }
            var result = await validator.ValidateAsync(dto);
            var error = result.Errors.FirstOrDefault();
            if (error == null)
            {
                return null;
            }

            if (!int.TryParse(error.ErrorCode ?? "1", out var code))
            {
                code = 1;
            }
            var apiResult = new ApiResult
            {
                ErrorNo = code,
                Message = error.ErrorMessage
            };
            return apiResult;
        }
    }
}
