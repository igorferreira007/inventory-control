using InventoryControl.Domain.Entities;
using InventoryControl.Domain.Exceptions;
using InventoryControl.Domain.Tests.Fatories;

namespace InventoryControl.Domain.Tests.Products;

public class ProductTests
{
    [Fact]
    public void Should_Create_Product()
    {
        // Arrange
        string name = "Test Product";
        string description = "This is a test product.";
        decimal price = 10.99m;
        // Act
        var product = Product.Create(name, price, description);
        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(price, product.Price);
        Assert.Equal(0, product.StockQuantity);
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Empty()
    {
        Assert.Throws<DomainException>(() => ProductFactory.Create(name: ""));
    }

    [Fact]
    public void Should_Throw_When_Changing_Name_To_Empty()
    {
        var product = ProductFactory.Create();

        Assert.Throws<DomainException>(() => product.ChangeName(""));
    }

    [Fact]
    public void Should_Throw_When_Price_Is_Invalid()
    {
        Assert.Throws<DomainException>(() => ProductFactory.Create(price: -5));
    }

    [Fact]
    public void Should_Throw_When_Changing_Price_To_Invalid_Value()
    {
        var product = ProductFactory.Create();

        Assert.Throws<DomainException>(() => product.ChangePrice(0));
    }

    [Fact]
    public void Should_Increase_Stock()
    {
        var product = ProductFactory.Create();

        product.IncreaseStock(10);

        Assert.Equal(10, product.StockQuantity);
    }

    [Fact]
    public void Should_Throw_When_Increase_Invalid_Quantity()
    {
        var product = ProductFactory.Create();
        
        Assert.Throws<DomainException>(() => product.IncreaseStock(0));
    }

    [Fact]
    public void Should_Decrease_Stock()
    {
        var product = ProductFactory.Create();

        product.IncreaseStock(20);
        product.DecreaseStock(5);
        
        Assert.Equal(15, product.StockQuantity);
    }

    [Fact]
    public void Should_Throw_When_Stock_Is_Insufficient()
    {
        var product = ProductFactory.Create();

        product.IncreaseStock(5);

        Assert.Throws<DomainException>(() => product.DecreaseStock(10));
    }

    [Fact]
    public void Should_Throw_When_Decrease_Invalid_Quantity()
    {
        var product = ProductFactory.Create();

        product.IncreaseStock(5);

        Assert.Throws<DomainException>(() => product.DecreaseStock(-5));
    }

    [Fact]
    public void Should_Change_Product_Name()
    {
        var product = ProductFactory.Create(name: "Test Product");

        product.ChangeName("Updated Product Name");

        Assert.Equal("Updated Product Name", product.Name);
    }

    [Fact]
    public void Should_Change_Product_Price()
    {
        var product = ProductFactory.Create(price: 10.99m);

        product.ChangePrice(5.58m);

        Assert.Equal(5.58m, product.Price);
    }

    [Fact]
    public void Should_Validate_The_Created_At()
    {
        var before = DateTime.UtcNow;

        var product = ProductFactory.Create();

        Assert.True(product.CreatedAt >= before);
    }
}
