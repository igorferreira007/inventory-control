using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;

namespace InventoryControl.Application.UseCases;

public class DeleteProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly IValidator<DeleteProductRequestDto> _validator;

    public DeleteProductUseCase(IProductRepository repository, IValidator<DeleteProductRequestDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Result> Execute(DeleteProductRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult;

        var productId = request.ProductId;

        var product = await _repository.FindByIdAsync(productId);

        if (product is null)
            return "Produto não encontrado.";

        await _repository.DeleteAsync(product);

        return Result.Success();
    }
}
