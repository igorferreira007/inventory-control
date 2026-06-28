using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;

namespace InventoryControl.Application.UseCases;

public class IncreaseProductStockUseCase
{
    private readonly IProductRepository _repository;
    private readonly IValidator<IncreaseProductStockRequestDto> _validator;

    public IncreaseProductStockUseCase(IProductRepository repository, IValidator<IncreaseProductStockRequestDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Result> Execute(IncreaseProductStockRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult;

        var (productId, quantity) = request;

        var product = await _repository.FindByIdAsync(productId);

        if (product is null)
            return "Produto não encontrado.";

        product.IncreaseStock(quantity);

        await _repository.SaveAsync(product);

        return Result.Success();
    }
}
