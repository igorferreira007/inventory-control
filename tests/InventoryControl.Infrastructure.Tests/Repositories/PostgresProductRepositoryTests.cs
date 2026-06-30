using InventoryControl.Domain.Entities;
using InventoryControl.Infrastructure.Database;
using InventoryControl.Infrastructure.Repositories;
using Npgsql;

namespace InventoryControl.Infrastructure.Tests.Repositories;

public class PostgresProductRepositoryTests
{
    private const string ConnectionString = "Host=localhost;Port=5432;Database=inventory_control;Username=postgres;Password=postgres";

    private readonly PostgresConnectionFactory _connectionFactory;
    private readonly PostgresProductRepository _repository;

    public PostgresProductRepositoryTests()
    {
        _connectionFactory = new PostgresConnectionFactory(ConnectionString);
        _repository = new PostgresProductRepository(_connectionFactory);
    }

    [Fact]
    public async Task Should_Create_Product()
    {
        await ClearDatabaseAsync();

        var product = Product.Create(
            name: "Product test",
            price: 10.99m,
            description: "Product description test.");

        await _repository.CreateAsync(product);

        Assert.True(product.Id > 0);

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        const string sql = """
            SELECT id, name, description, price, stock_quantity
            FROM products
            WHERE id = @id;
            """;

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", product.Id);

        await using var reader = await command.ExecuteReaderAsync();

        Assert.True(await reader.ReadAsync());

        Assert.Equal(product.Id, reader.GetInt64(0));
        Assert.Equal("Product test", reader.GetString(1));
        Assert.Equal("Product description test.", reader.GetString(2));
        Assert.Equal(10.99m, reader.GetDecimal(3));
        Assert.Equal(0, reader.GetInt32(4));
    }

    [Fact]
    public async Task Should_Find_Product_By_Id()
    {
        await ClearDatabaseAsync();

        var product = Product.Create(
            name: "Product test",
            price: 10.99m,
            description: "Product description test.");

        await _repository.CreateAsync(product);

        var productFound = await _repository.FindByIdAsync(product.Id);

        Assert.NotNull(productFound);
        Assert.Equal(product.Id, productFound.Id);
        Assert.Equal("Product test", productFound.Name);
        Assert.Equal(10.99m, productFound.Price);
        Assert.Equal("Product description test.", productFound.Description);
        Assert.Equal(0, productFound.StockQuantity);
    }

    [Fact]
    public async Task Should_Return_Null_When_Product_Does_Not_Exist()
    {
        await ClearDatabaseAsync();

        var productFound = await _repository.FindByIdAsync(999);

        Assert.Null(productFound);
    }

    [Fact]
    public async Task Should_Find_Product_By_Name()
    {
        await ClearDatabaseAsync();

        var product = Product.Create(
            name: "Product test",
            price: 10.99m,
            description: "Product description test.");

        await _repository.CreateAsync(product);

        var productFound = await _repository.FindByNameAsync(product.Name);

        Assert.NotNull(productFound);
        Assert.Equal(product.Id, productFound.Id);
        Assert.Equal("Product test", productFound.Name);
        Assert.Equal(10.99m, productFound.Price);
        Assert.Equal("Product description test.", productFound.Description);
        Assert.Equal(product.StockQuantity, productFound.StockQuantity);
    }

    [Fact]
    public async Task Should_Find_Product_By_Name_Ignoring_Case()
    {
        await ClearDatabaseAsync();

        var product = Product.Create(
            name: "Product test",
            price: 10.99m,
            description: "Product description test.");

        await _repository.CreateAsync(product);

        var productFound = await _repository.FindByNameAsync("PRODUCT TEST");

        Assert.NotNull(productFound);
        Assert.Equal(product.Id, productFound.Id);
        Assert.Equal("Product test", productFound.Name);
    }

    [Fact]
    public async Task Should_Return_Null_When_Product_Name_Does_Not_Exist()
    {
        await ClearDatabaseAsync();

        var productFound = await _repository.FindByNameAsync("PRODUCT TEST");

        Assert.Null(productFound);
    }

    [Fact]
    public async Task Should_Find_Many_Products()
    {
        await ClearDatabaseAsync();

        await _repository.CreateAsync(Product.Create(
            name: "Notebook",
            price: 3500m));

        await _repository.CreateAsync(Product.Create(
            name: "Mouse",
            price: 150m));

        await _repository.CreateAsync(Product.Create(
            name: "Keyboard",
            price: 300m));

        var products = await _repository.FindManyAsync(pageNumber: 1, pageSize: 20);

        Assert.Equal(3, products.Count);
        Assert.Equal(new List<string> { "Keyboard", "Mouse", "Notebook" }, [.. products.Select(p => p.Name)]);
    }

    [Fact]
    public async Task Should_Filter_Products_By_Search_Term()
    {
        await ClearDatabaseAsync();

        await _repository.CreateAsync(Product.Create(
            name: "Notebook Dell",
            price: 3500m));

        await _repository.CreateAsync(Product.Create(
            name: "Mouse Logitech",
            price: 150m));

        await _repository.CreateAsync(Product.Create(
            name: "Notebook Lenovo",
            price: 4000m));

        var products = await _repository.FindManyAsync(pageNumber: 1, pageSize: 20, searchTerm: "Notebook");

        Assert.Equal(2, products.Count);
        Assert.Equal(new List<string> { "Notebook Dell", "Notebook Lenovo" }, [.. products.Select(p => p.Name)]);
    }

    [Fact]
    public async Task Should_Return_Products_From_Second_Page()
    {
        await ClearDatabaseAsync();

        for (int i = 1; i <= 22; i++)
        {
            await _repository.CreateAsync(Product.Create(
            name: $"Product {i:00}",
            price: 10m));
        }

        var products = await _repository.FindManyAsync(
            pageNumber: 2,
            pageSize: 20);

        Assert.Equal(2, products.Count);
        Assert.Equal("Product 21", products[0].Name);
        Assert.Equal("Product 22", products[1].Name);
    }

    private async Task ClearDatabaseAsync()
    {
        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        const string sql = "TRUNCATE TABLE products RESTART IDENTITY;";

        await using var command = new NpgsqlCommand(sql, connection);
        await command.ExecuteNonQueryAsync();
    }
}
