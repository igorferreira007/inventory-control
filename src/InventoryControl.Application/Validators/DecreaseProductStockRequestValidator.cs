using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;

namespace InventoryControl.Application.Validators;

public class DecreaseProductStockRequestValidator : AbstractValidator<DecreaseProductStockRequestDto>
{
    public DecreaseProductStockRequestValidator()
    {
        RuleFor(p => p.ProductId).GreaterThan(0).WithMessage(ResourceMessages.PRODUCT_ID_INVALID);
        RuleFor(p => p.Quantity).GreaterThan(0).WithMessage(ResourceMessages.QUANTITY_GREATER_THAN_ZERO);
    }
}
