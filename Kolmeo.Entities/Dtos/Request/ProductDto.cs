
using FluentValidation;

namespace Kolmeo.Entities.Dtos.Request
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(dto => dto.Name)
                .NotNull().WithMessage("Name is required")
                .NotEmpty().WithMessage("Name is required");
            RuleFor(dto => dto.Price)
                .NotEmpty().WithMessage("Price is required")
                .NotNull().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price should be greater than 0");
        }
    }

}
