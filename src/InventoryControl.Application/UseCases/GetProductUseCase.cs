using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;

namespace InventoryControl.Application.UseCases;

public class GetProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<GetProductRequestDto> _validator;

    public GetProductUseCase(IProductRepository productRepository, IValidator<GetProductRequestDto> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }

    public async Task<Result<ProductResponseDto>> Execute(GetProductRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult;

        var productId = request.ProductId;

        var product = await _productRepository.FindByIdAsync(productId);

        if (product is null)
            return "Produto não encontrado.";

        return new ProductResponseDto(
            product.Id, 
            product.Name, 
            product.Price, 
            product.StockQuantity, 
            product.Description, 
            product.CreatedAt);
    }
}
