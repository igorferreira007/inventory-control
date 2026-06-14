using InventoryControl.Domain.Entities;
using InventoryControl.Domain.Exceptions;

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
        var product = Product.Create(name, description, price);
        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(description, product.Description);
        Assert.Equal(price, product.Price);
        Assert.Equal(0, product.StockQuantity);
    }

    [Fact]
    public void Should_Throw_When_Name_Is_Empty()
    {
        // Arrange
        string name = "";
        decimal price = 10.99m;
        // Act & Assert
        Assert.Throws<DomainException>(() => Product.Create(name, null, price));
    }

    [Fact]
    public void Should_Throw_When_Changing_Name_To_Empty()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        // Act & Assert
        Assert.Throws<DomainException>(() => product.ChangeName(""));
    }

    [Fact]
    public void Should_Throw_When_Price_Is_Invalid()
    {
        // Arrange
        string name = "Test Product";
        decimal price = -5.00m;
        // Act & Assert
        Assert.Throws<DomainException>(() => Product.Create(name, null, price));
    }

    [Fact]
    public void Should_Throw_When_Changing_Price_To_Invalid_Value()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        // Act & Assert
        Assert.Throws<DomainException>(() => product.ChangePrice(0));
    }

    [Fact]
    public void Should_Increase_Stock()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        int quantityToAdd = 10;
        // Act
        product.IncreaseStock(quantityToAdd);
        // Assert
        Assert.Equal(quantityToAdd, product.StockQuantity);
    }

    [Fact]
    public void Should_Throws_When_Increase_Invalid_Quantity()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        int quantityToAdd = 0;
        // Act & Assert
        Assert.Throws<DomainException>(() => product.IncreaseStock(quantityToAdd));
    }

    [Fact]
    public void Should_Decrease_Stock()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        product.IncreaseStock(20);
        int quantityToRemove = 5;
        // Act
        product.DecreaseStock(quantityToRemove);
        // Assert
        Assert.Equal(15, product.StockQuantity);
    }

    [Fact]
    public void Should_Throws_When_Stock_Is_Insufficient()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        product.IncreaseStock(5);
        int quantityToRemove = 10;
        // Act & Assert
        Assert.Throws<DomainException>(() => product.DecreaseStock(quantityToRemove));
    }

    [Fact]
    public void Should_Throws_When_Decrease_Invalid_Quantity()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        product.IncreaseStock(5);
        int quantityToRemove = -5;
        // Act & Assert
        Assert.Throws<DomainException>(() => product.DecreaseStock(quantityToRemove));
    }

    [Fact]
    public void Should_Change_Product_Name()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        string newName = "Updated Product Name";
        // Act
        product.ChangeName(newName);
        // Assert
        Assert.Equal(newName, product.Name);
    }

    [Fact]
    public void Should_Change_Product_Price()
    {
        // Arrange
        var product = Product.Create("Test Product", null, 10.99m);
        decimal newPrice = 5.58m;
        // Act
        product.ChangePrice(newPrice);
        // Assert
        Assert.Equal(newPrice, product.Price);
    }

    [Fact]
    public void Should_Set_CreatedAt_On_Creation()
    {
        // Arrange
        var before = DateTime.UtcNow;
        // Act
        var product = Product.Create("Test Product", null, 10.99m);
        // Assert
        Assert.True(product.CreatedAt >= before);
    }
}
