using FluentValidation;
using Kolmeo.DataServices.IConfig;
using Kolmeo.DataServices.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Kolmeo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICustomValidators _validators;

        public BaseController(IUnitOfWork unitOfWork, ICustomValidators validators)
        {
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

    }
}
