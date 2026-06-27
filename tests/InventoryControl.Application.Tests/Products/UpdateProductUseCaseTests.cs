using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;
using InventoryControl.Application.Tests.Factories;
using InventoryControl.Application.Tests.Repositories;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;
using Xunit.Abstractions;

namespace InventoryControl.Application.Tests.Products;

public class UpdateProductUseCaseTests
{
    private readonly InMemoryProductRepository _repository;
    private readonly UpdateProductUseCase _sut;

    public UpdateProductUseCaseTests()
    {
        _repository = new InMemoryProductRepository();
        _sut = new UpdateProductUseCase(_repository, new UpdateProductRequestValidator());
    }

    [Fact]
    public async Task Should_Update_Product()
    {
        _repository.Add(ProductFactory.Create(id: 1, name: "Produt name", description: "Product description", price: 10.99m));
        var productDto = new UpdateProductRequestDto(
            ProductId: 1,
            Name: "Product name changed",
            Description: "Product description changed",
            Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal("Product name changed", _repository.Products[0].Name);
        Assert.Equal("Product description changed", _repository.Products[0].Description);
        Assert.Equal(15.59m, _repository.Products[0].Price);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Does_Not_Exist()
    {
        var productDto = new UpdateProductRequestDto(
            ProductId: 1,
            Name: "Product name changed",
            Description: "Product description changed",
            Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Empty(_repository.Products);
        Assert.Equal("Produto não encontrado.", result.Message);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Id_Is_Invalid()
    {
        const string productName = "Product name";
        _repository.Add(ProductFactory.Create(name: productName));
        var productDto = new UpdateProductRequestDto(
            ProductId: -1,
            Name: "Product name changed",
            Description: "Product description changed",
            Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal(ResourceMessages.PRODUCT_ID_INVALID, result.Message);
        Assert.Equal(productName, _repository.Products[0].Name);
    }

    [Fact]
    public async Task Should_Fail_When_Name_Is_Empty()
    {
        const string productName = "Product name";
        _repository.Add(ProductFactory.Create(name: productName));
        var productDto = new UpdateProductRequestDto(
           ProductId: 1,
           Name: "",
           Description: "Product description changed",
           Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Contains(ResourceMessages.PRODUCT_NAME_REQUIRED, result.Message);
        Assert.Contains(ResourceMessages.PRODUCT_NAME_MINIMUM_LENGTH, result.Message);
        Assert.Equal(productName, _repository.Products[0].Name);
    }

    [Fact]
    public async Task Should_Fail_When_Name_Is_Less_Than_Two_Characters()
    {
        const string productName = "Product name";
        _repository.Add(ProductFactory.Create(name: productName));
        var productDto = new UpdateProductRequestDto(
           ProductId: 1,
           Name: "P",
           Description: "Product description changed",
           Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Contains(ResourceMessages.PRODUCT_NAME_MINIMUM_LENGTH, result.Message);
        Assert.Equal(productName, _repository.Products[0].Name);
    }

    [Fact]
    public async Task Should_Fail_When_Name_Is_Greater_Than_Hundred_Characters()
    {
        const string productName = "Product name";
        _repository.Add(ProductFactory.Create(name: productName));
        var productDto = new UpdateProductRequestDto(
           ProductId: 1,
           Name: new string('A', 101),
           Description: "Product description changed",
           Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Contains(ResourceMessages.PRODUCT_NAME_MAXIMUM_LENGTH, result.Message);
        Assert.Equal(productName, _repository.Products[0].Name);
    }

    [Fact]
    public async Task Should_Fail_When_Price_Is_Invalid()
    {
        const decimal productPrice = 10.99m;
        _repository.Add(ProductFactory.Create(price: productPrice));
        var productDto = new UpdateProductRequestDto(
           ProductId: 1,
           Name: "Product name changed",
           Description: "Product description changed",
           Price: 0);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Contains(ResourceMessages.PRODUCT_PRICE_GREATER_THAN_ZERO, result.Message);
        Assert.Equal(productPrice, _repository.Products[0].Price);
    }

    [Fact]
    public async Task Should_Fail_When_Description_Is_Too_Long()
    {
        const string productDescription = "Product description.";
        _repository.Add(ProductFactory.Create(description: productDescription));
        var productDto = new UpdateProductRequestDto(
           ProductId: 1,
           Name: "Product name changed",
           Description: new string('A', 1001),
           Price: 15.59m);

        var result = await _sut.Execute(productDto);
        
        Assert.True(result.IsFailure);
        Assert.Equal(ResourceMessages.PRODUCT_DESCRIPTION_MAXIMUM_LENGTH, result.Message);
        Assert.Equal(productDescription, _repository.Products[0].Description);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Name_Already_Exists()
    {
        _repository.Add(ProductFactory.Create(id: 1, name: "Produt name 1"));
        _repository.Add(ProductFactory.Create(id: 2, name: "Produt name 2"));
        var productDto = new UpdateProductRequestDto(
            ProductId: 1,
            Name: "Produt name 2",
            Description: "Product description changed",
            Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Equal("Um produto com esse nome já existe.", result.Message);
        Assert.Equal("Produt name 1", _repository.Products[0].Name);
        Assert.Equal("Produt name 2", _repository.Products[1].Name);
    }

    [Fact]
    public async Task Should_Update_Only_Selected_Product()
    {
        _repository.Add(ProductFactory.Create(id: 1, name: "Produt name 1"));
        _repository.Add(ProductFactory.Create(id: 2, name: "Produt name 2"));
        var productDto = new UpdateProductRequestDto(
            ProductId: 2,
            Name: "Produt name 2 changed",
            Description: "Product description changed",
            Price: 15.59m);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal("Produt name 1", _repository.Products[0].Name);
        Assert.Equal("Produt name 2 changed", _repository.Products[1].Name);
    }
}
