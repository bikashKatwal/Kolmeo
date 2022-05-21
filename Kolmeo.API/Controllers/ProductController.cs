using Kolmeo.DataServices.IConfig;
using Kolmeo.Entities.DbSet;
using Kolmeo.Entities.Dtos.Request;
using Kolmeo.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolmeo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        [HttpGet("/GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAll();
            return Ok(products);
        }

        [HttpGet("/GetProduct")]
        public async Task<IActionResult> GetProduct(Guid Id)
        {
            var product = await _unitOfWork.Products.GetById(Id);
            if (product == null) NotFound();
            return Ok(product);
        }

        [HttpGet("/GetProductByName")]
        public async Task<IActionResult> GetProductByName(string ProductName)
        {
            var _product = await _unitOfWork.Products.GetProductByName(ProductName);
            if (_product == null) NotFound();
            return Ok(_product);
        }

        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            var result = await ValidateAsync(product, new ProductValidator());

            if (result != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            var _product = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = Decimal.Parse(product.Price.ToString("0.00")),
            };
            await _unitOfWork.Products.Add(_product);
            await _unitOfWork.CompleteAsync();
            return Ok(new ApiResult() { ErrorNo = 0, Message = "Saved Sucessfully" });
        }

    }
}
