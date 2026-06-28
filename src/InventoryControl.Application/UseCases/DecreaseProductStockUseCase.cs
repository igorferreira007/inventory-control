using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;

namespace InventoryControl.Application.UseCases;

public class DecreaseProductStockUseCase
{
    private readonly IProductRepository _repository;
    private readonly IValidator<DecreaseProductStockRequestDto> _validator;

    public DecreaseProductStockUseCase(IProductRepository repository, IValidator<DecreaseProductStockRequestDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Result> Execute(DecreaseProductStockRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult;

        var (productId, quantity) = request;

        var product = await _repository.FindByIdAsync(productId);

        if (product is null)
            return "Produto não encontrado.";

        if (product.StockQuantity == 0)
            return "Produto sem estoque.";

        if (product.StockQuantity < quantity)
            return "Quantidade indisponível.";

        product.DecreaseStock(quantity);

        await _repository.SaveAsync(product);

        return Result.Success();
    }
}
