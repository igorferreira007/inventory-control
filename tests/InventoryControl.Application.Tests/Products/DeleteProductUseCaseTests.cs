using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;
using InventoryControl.Application.Tests.Factories;
using InventoryControl.Application.Tests.Repositories;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;

namespace InventoryControl.Application.Tests.Products;

public class DeleteProductUseCaseTests
{
    private readonly InMemoryProductRepository _repository;
    private readonly DeleteProductUseCase _sut;

    public DeleteProductUseCaseTests()
    {
        _repository = new InMemoryProductRepository();
        _sut = new DeleteProductUseCase(_repository, new DeleteProductRequestValidator());
    }

    [Fact]
    public async Task Should_Delete_Product()
    {
        _repository.Add(ProductFactory.Create(id: 1));
        var productDto = new DeleteProductRequestDto(ProductId: 1);

        Assert.Single(_repository.Products);
        Assert.Equal(1, _repository.Products[0].Id);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Empty(_repository.Products);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Does_Not_Exist()
    {
        var productDto = new DeleteProductRequestDto(ProductId: 1);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal("Produto não encontrado.", result.Message);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Id_Is_Invalid()
    {
        var productDto = new DeleteProductRequestDto(ProductId: -1);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal(ResourceMessages.PRODUCT_ID_INVALID, result.Message);
    }

    [Fact]
    public async Task Should_Delete_Only_Selected_Product()
    {
        _repository.Add(ProductFactory.Create(id: 1));
        _repository.Add(ProductFactory.Create(id: 2));
        var productDto = new DeleteProductRequestDto(ProductId: 2);

        Assert.Equal(2, _repository.Products.Count);
        Assert.Equal(1, _repository.Products[0].Id);
        Assert.Equal(2, _repository.Products[1].Id);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Single(_repository.Products);
        Assert.Contains(_repository.Products, product => product.Id == 1);
        Assert.DoesNotContain(_repository.Products, product => product.Id == 2);
    }
}
