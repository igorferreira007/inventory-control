using InventoryControl.Application.DTOs;
using InventoryControl.Application.Resources;
using InventoryControl.Application.Tests.Factories;
using InventoryControl.Application.Tests.Repositories;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;
using InventoryControl.Domain.Entities;
using Xunit.Abstractions;

namespace InventoryControl.Application.Tests.Products;

public class ListProductsUseCaseTests
{
    private readonly InMemoryProductRepository _repository;
    private readonly ListProductsUseCase _sut;
    private readonly ITestOutputHelper _output;

    public ListProductsUseCaseTests(ITestOutputHelper output)
    {
        _output = output;

        _repository = new InMemoryProductRepository();
        _sut = new ListProductsUseCase(_repository, new ListProductsRequestValidator());
    }

    [Fact]
    public async Task Should_List_All_Products()
    {
        _repository.Products.Add(ProductFactory.Create(id: 1));
        _repository.Products.Add(ProductFactory.Create(id: 2));
        _repository.Products.Add(ProductFactory.Create(id: 3));
        var request = new ListProductsRequestDto(PageNumber: 1, PageSize: 20);

        var result = await _sut.Execute(request);

        var products = result.Value!.Products;

        var productsIds = products.Select(p => p.Id).ToList();

        Assert.True(result.IsSuccess);
        Assert.Equal(3, products.Count);
        Assert.Contains(products, p => p.Id == 1);
        Assert.Contains(products, p => p.Id == 2);
        Assert.Contains(products, p => p.Id == 3);
    }

    [Fact]
    public async Task Should_Return_Empty_List_When_There_Are_No_Products()
    {
        var request = new ListProductsRequestDto(PageNumber: 1, PageSize: 20);

        var result = await _sut.Execute(request);

        Assert.True(result.IsSuccess);
        Assert.Empty(_repository.Products);
        Assert.Empty(result.Value!.Products);
    }

    [Fact]
    public async Task Should_Filter_Products_By_Search_Term()
    {
        _repository.Products.Add(ProductFactory.Create(id: 1, name: "Product test 1"));
        _repository.Products.Add(ProductFactory.Create(id: 2, name: "Product test 2"));
        _repository.Products.Add(ProductFactory.Create(id: 3, name: "Product test 3"));
        var request = new ListProductsRequestDto(PageNumber: 1, PageSize: 20, SearchTerm: "Product test 2");

        var result = await _sut.Execute(request);

        var products = result.Value!.Products;

        Assert.True(result.IsSuccess);
        Assert.Single(products);
        Assert.Equal(2, products[0].Id);
        Assert.Equal("Product test 2", products[0].Name);
    }

    [Fact]
    public async Task Should_Return_Only_Page_Size_Products()
    {
        _repository.Products.Add(ProductFactory.Create(id: 1));
        _repository.Products.Add(ProductFactory.Create(id: 2));
        _repository.Products.Add(ProductFactory.Create(id: 3));
        var request = new ListProductsRequestDto(PageNumber: 1, PageSize: 1);

        var result = await _sut.Execute(request);

        var products = result.Value!.Products;

        Assert.True(result.IsSuccess);
        Assert.Equal(3, _repository.Products.Count);
        Assert.Single(products);
        Assert.Equal(1, products[0].Id);
        Assert.Equal("Product test 1", products[0].Name);
    }

    [Fact]
    public async Task Should_Return_Products_From_Second_Page()
    {
        _repository.Products.Add(ProductFactory.Create(id: 1));
        _repository.Products.Add(ProductFactory.Create(id: 2));
        _repository.Products.Add(ProductFactory.Create(id: 3));
        var request = new ListProductsRequestDto(PageNumber: 2, PageSize: 1);

        var result = await _sut.Execute(request);

        var products = result.Value!.Products;

        Assert.True(result.IsSuccess);
        Assert.Equal(3, _repository.Products.Count);
        Assert.Single(products);
        Assert.Equal(2, products[0].Id);
        Assert.Equal("Product test 2", products[0].Name);
    }

    [Fact]
    public async Task Should_Fail_When_Page_Number_Is_Invalid()
    {
        var request = new ListProductsRequestDto(PageNumber: -1, PageSize: 1);

        var result = await _sut.Execute(request);

        Assert.True(result.IsFailure);
        Assert.Null(result.Value);
        Assert.Equal(ResourceMessages.PAGE_NUMBER_GREATER_THAN_ZERO, result.Message);
    }

    [Fact]
    public async Task Should_Fail_When_Page_Size_Is_Invalid()
    {
        var request = new ListProductsRequestDto(PageNumber: 1, PageSize: -1);

        var result = await _sut.Execute(request);

        Assert.True(result.IsFailure);
        Assert.Null(result.Value);
        Assert.Equal(ResourceMessages.PAGE_SIZE_GREATER_THAN_ZERO, result.Message);
    }
}
