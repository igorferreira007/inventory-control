using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;
using InventoryControl.Application.Resources;
using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.UseCases;

public class CreateProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductRequestDto> _validator;

    public CreateProductUseCase(IProductRepository productRepository, IValidator<CreateProductRequestDto> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }

    public async Task<Result> Execute(CreateProductRequestDto productDto)
    {
        var validationResult = await _validator.ValidateAsync(productDto);

        if (!validationResult.IsValid)
            return validationResult;

        var (name, price, description) = productDto;

        var productExists = await _productRepository.FindByNameAsync(name);

        if (productExists is not null)
        {
            return ResourceMessages.PRODUCT_ALREADY_EXISTS;
        }

        var product = Product.Create(name, price, description);

        await _productRepository.CreateAsync(product);

        return Result.Success();
    }
}
