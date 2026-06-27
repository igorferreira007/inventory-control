using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;

namespace InventoryControl.Application.UseCases;

public class UpdateProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly IValidator<UpdateProductRequestDto> _validator;

    public UpdateProductUseCase(IProductRepository repository, IValidator<UpdateProductRequestDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<Result> Execute(UpdateProductRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult;

        var (productId, name, price, description) = request;

        var product = await _repository.FindByIdAsync(productId);

        if (product is null)
            return "Produto não encontrado.";

        var productWithSameName = await _repository.FindByNameAsync(name);

        if (productWithSameName is not null && productWithSameName.Id != productId)
            return "Um produto com esse nome já existe.";

        product.ChangeName(name);
        product.ChangePrice(price);
        product.ChangeDescription(description);

        await _repository.SaveAsync(product);

        return Result.Success();
    }
}
