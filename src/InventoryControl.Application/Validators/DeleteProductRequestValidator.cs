using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;

namespace InventoryControl.Application.Validators;

public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequestDto>
{
    public DeleteProductRequestValidator()
    {
        RuleFor(p => p.ProductId).GreaterThan(0).WithMessage(ResourceMessages.PRODUCT_ID_INVALID);
    }
}
