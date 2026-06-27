using InventoryControl.Application.DTOs;
using InventoryControl.Application.Tests.Repositories;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;
using InventoryControl.Domain.Entities;
using Xunit.Abstractions;

namespace InventoryControl.Application.Tests.Products;

public class GetProductUseCaseTests
{
    private readonly InMemoryProductRepository _repository;
    private readonly GetProductUseCase _sut;
    private readonly ITestOutputHelper _output;

    public GetProductUseCaseTests(ITestOutputHelper output)
    {
        _output = output;

        _repository = new InMemoryProductRepository();
        _sut = new GetProductUseCase(_repository, new GetProductRequestValidator());
    }

    [Fact]
    public async Task Should_Get_Product()
    {
        var product = Product.Restore(1, "Product test", 10.99m, 10, DateTime.UtcNow, "Product description test.");
        _repository.Products.Add(product);
        var request = new GetProductRequestDto(1);

        var result = await _sut.Execute(request);

        var expected = new ProductResponseDto(
            product.Id,
            product.Name,
            product.Price,
            product.StockQuantity,
            product.Description,
            product.CreatedAt);

        _output.WriteLine(result.Value?.ToString());

        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Does_Not_Exists()
    {
        var request = new GetProductRequestDto(1);

        var result = await _sut.Execute(request);
        
        Assert.True(result.IsFailure);
        Assert.Null(result.Value);
        Assert.Contains("Produto não encontrado.", result.Message);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Id_Is_Invalid()
    {
        var request = new GetProductRequestDto(-1);

        var result = await _sut.Execute(request);

        Assert.True(result.IsFailure);
        Assert.Null(result.Value);
        Assert.Contains("Id inválido.", result.Message);
    }
}
