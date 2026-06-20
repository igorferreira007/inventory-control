using InventoryControl.Application.Tests.Factories;
using InventoryControl.Application.Tests.Repositories;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;

namespace InventoryControl.Application.Tests.Products;

public class CreateProductUseCaseTests
{
    private readonly InMemoryProductRepository _repository;
    private readonly CreateProductUseCase _sut;

    public CreateProductUseCaseTests()
    {
        _repository = new InMemoryProductRepository();
        _sut = new CreateProductUseCase(_repository, new CreateProductRequestValidator());
    }

    [Fact]
    public async Task Should_Create_Product()
    {
        var productDto = CreateProductRequestDtoFactory.Create();

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Equal(productDto.Name, _repository.Products[0].Name);
    }

    [Fact]
    public async Task Should_Fail_When_Name_Is_Empty()
    {
        var productDto = CreateProductRequestDtoFactory.Create(name: "");

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Empty(_repository.Products);
    }

    [Fact]
    public async Task Should_Fail_When_Price_Is_Invalid()
    {
        var productDto = CreateProductRequestDtoFactory.Create(price: 0);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Empty(_repository.Products);
    }

    [Fact]
    public async Task Should_Fail_When_Product_Name_Already_Exists()
    {
        var productDto = CreateProductRequestDtoFactory.Create();

        await _sut.Execute(productDto);
        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Single(_repository.Products);
    }

    [Fact]
    public async Task Should_Return_Multiple_Validation_Errors()
    {
        var productDto = CreateProductRequestDtoFactory.Create(name: "", price: 0);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Empty(_repository.Products);
    }

    [Fact]
    public async Task Should_Fail_When_Description_Is_Too_Long()
    {
        string longDescription = new string('A', 1001);

        var productDto = CreateProductRequestDtoFactory.Create(description: longDescription);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsFailure);
        Assert.Empty(_repository.Products);
    }

    [Fact]
    public async Task Should_Create_Product_With_Maximum_Description_Length()
    {
        string longDescription = new string('A', 1000);

        var productDto = CreateProductRequestDtoFactory.Create(description: longDescription);

        var result = await _sut.Execute(productDto);

        Assert.True(result.IsSuccess);
        Assert.Single(_repository.Products);
    }
}
