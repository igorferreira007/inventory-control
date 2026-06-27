using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;

namespace InventoryControl.Application.Validators;

public class ListProductsRequestValidator : AbstractValidator<ListProductsRequestDto>
{
    public ListProductsRequestValidator()
    {
        RuleFor(request => request.PageNumber)
            .GreaterThan(0).WithMessage(ResourceMessages.PAGE_NUMBER_GREATER_THAN_ZERO);
        RuleFor(request => request.PageSize)
            .GreaterThan(0).WithMessage(ResourceMessages.PAGE_SIZE_GREATER_THAN_ZERO);
        RuleFor(request => request.SearchTerm)
            .MaximumLength(100)
            .WithMessage(ResourceMessages.SEARCH_TERM_MAX_LENGTH);
    }
}
