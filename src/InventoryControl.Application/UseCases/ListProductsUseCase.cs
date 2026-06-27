using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Interfaces;

namespace InventoryControl.Application.UseCases;

public class ListProductsUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<ListProductsRequestDto> _validator;

    public ListProductsUseCase(IProductRepository productRepository, IValidator<ListProductsRequestDto> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }

    public async Task<Result<ListProductsResponseDto>> Execute(ListProductsRequestDto request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            return validationResult;

        var (pageNumber, pageSize, searchTerm) = request;

        var productEntities = await _productRepository.FindManyAsync(pageNumber, pageSize, searchTerm);

        var products = productEntities
            .Select(p => new ProductResponseDto(
                Id: p.Id,
                Name: p.Name,
                Price: p.Price,
                StockQuantity: p.StockQuantity,
                Description: p.Description,
                CreatedAt: p.CreatedAt))
            .ToList();

        return new ListProductsResponseDto(products);
    }
}
