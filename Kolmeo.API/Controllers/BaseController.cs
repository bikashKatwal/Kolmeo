using FluentValidation;
using Kolmeo.DataServices.IConfig;
using Kolmeo.Entities.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Kolmeo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task<ApiResult> ValidateAsync<TRequest>(TRequest dto, AbstractValidator<TRequest> validator)
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
