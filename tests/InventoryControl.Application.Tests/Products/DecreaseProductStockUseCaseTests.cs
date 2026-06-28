using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;
using InventoryControl.Application.Tests.Factories;
using InventoryControl.Application.Tests.Repositories;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;

namespace InventoryControl.Application.Tests.Products;

public class DecreaseProductStockUseCaseTests
{
    private readonly InMemoryProductRepository _repository;
    private readonly DecreaseProductStockUseCase _sut;

    public DecreaseProductStockUseCaseTests()
    {
        _repository = new InMemoryProductRepository();
        _sut = new DecreaseProductStockUseCase(_repository, new DecreaseProductStockRequestValidator());
    }

    [Fact]
    public async Task Should_Decrease_Product_Stock()
    {
        _repository.Add(ProductFactory.Create(id: 1, stockQuantity: 10));
        var productDto = new DecreaseProductStockRequestDto(ProductId: 1, Quantity: 5);

        Assert.Equal(10, _repository.Products[0].StockQuantity);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal(5, _repository.Products[0].StockQuantity);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Does_Not_Exist()
    {
        var productDto = new DecreaseProductStockRequestDto(ProductId: 1, Quantity: 10);

        Assert.Empty(_repository.Products);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal("Produto não encontrado.", result.Message);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Id_Is_Invalid()
    {
        var productDto = new DecreaseProductStockRequestDto(ProductId: -1, Quantity: 10);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal(ResourceMessages.PRODUCT_ID_INVALID, result.Message);
    }

    [Fact]
    public async Task Should_Fail_When_Quantity_Is_Invalid()
    {
        var productDto = new DecreaseProductStockRequestDto(ProductId: 1, Quantity: -10);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal(ResourceMessages.QUANTITY_GREATER_THAN_ZERO, result.Message);
    }

    [Fact]
    public async Task Should_Decrease_Stock_Only_Selected_Product()
    {
        _repository.Add(ProductFactory.Create(id: 1, stockQuantity: 10));
        _repository.Add(ProductFactory.Create(id: 2, stockQuantity: 10));
        var productDto = new DecreaseProductStockRequestDto(ProductId: 2, Quantity: 5);

        Assert.Equal(10, _repository.Products[0].StockQuantity);
        Assert.Equal(10, _repository.Products[1].StockQuantity);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal(10, _repository.Products[0].StockQuantity);
        Assert.Equal(5, _repository.Products[1].StockQuantity);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Stock_Is_Empty()
    {
        _repository.Add(ProductFactory.Create(id: 1, stockQuantity: 0));
        var productDto = new DecreaseProductStockRequestDto(ProductId: 1, Quantity: 5);

        Assert.Equal(0, _repository.Products[0].StockQuantity);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal("Produto sem estoque.", result.Message);
        Assert.Equal(0, _repository.Products[0].StockQuantity);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Stock_Quantity_Is_Unavailable()
    {
        _repository.Add(ProductFactory.Create(id: 1, stockQuantity: 10));
        var productDto = new DecreaseProductStockRequestDto(ProductId: 1, Quantity: 15);

        Assert.Equal(10, _repository.Products[0].StockQuantity);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal("Quantidade indisponível.", result.Message);
        Assert.Equal(10, _repository.Products[0].StockQuantity);
    }

    [Fact]
    public async Task Should_Decrease_Product_Stock_To_Zero()
    {
        _repository.Add(ProductFactory.Create(id: 1, stockQuantity: 10));

        Assert.Equal(10, _repository.Products[0].StockQuantity);

        var productDto = new DecreaseProductStockRequestDto(ProductId: 1, Quantity: 10);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal(0, _repository.Products[0].StockQuantity);
    }
}
