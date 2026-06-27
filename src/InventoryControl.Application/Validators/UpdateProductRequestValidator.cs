using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;

namespace InventoryControl.Application.Validators;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequestDto>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(p => p.ProductId)
            .GreaterThan(0).WithMessage(ResourceMessages.PRODUCT_ID_INVALID);
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage(ResourceMessages.PRODUCT_NAME_REQUIRED)
            .MinimumLength(2).WithMessage(ResourceMessages.PRODUCT_NAME_MINIMUM_LENGTH)
            .MaximumLength(100).WithMessage(ResourceMessages.PRODUCT_NAME_MAXIMUM_LENGTH);
        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage(ResourceMessages.PRODUCT_PRICE_GREATER_THAN_ZERO);
        RuleFor(product => product.Description)
            .MaximumLength(1000).WithMessage(ResourceMessages.PRODUCT_DESCRIPTION_MAXIMUM_LENGTH);
    }
}
