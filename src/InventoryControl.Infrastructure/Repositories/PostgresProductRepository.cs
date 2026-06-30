using InventoryControl.Application.Interfaces;
using InventoryControl.Domain.Entities;
using InventoryControl.Infrastructure.Database;
using Npgsql;

namespace InventoryControl.Infrastructure.Repositories;

public class PostgresProductRepository : IProductRepository
{
    private readonly PostgresConnectionFactory _connectionFactory;

    public PostgresProductRepository(PostgresConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task CreateAsync(Product product)
    {
        const string sql = """
            INSERT INTO products (
                name,
                description,
                price,
                stock_quantity,
                created_at
            )
            VALUES (
                @name,
                @description,
                @price,
                @stock_quantity,
                @created_at
            )
            RETURNING id;
            """;

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@description", product.Description is null ? DBNull.Value : product.Description);
        command.Parameters.AddWithValue("@price", product.Price);
        command.Parameters.AddWithValue("@stock_quantity", product.StockQuantity);
        command.Parameters.AddWithValue("@created_at", product.CreatedAt);

        var generateId = await command.ExecuteScalarAsync();

        product.AssignId((long)generateId!);
    }

    public async Task DeleteAsync(Product product)
    {
        const string sql = """
            DELETE FROM products
            WHERE id = @id;
            """;

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", product.Id);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<Product?> FindByIdAsync(long id)
    {
        const string sql = """
            SELECT id, name, description, price, stock_quantity, created_at
            FROM products
            WHERE id = @id;
            """;

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        await using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return Product.Restore(
            id: reader.GetInt64(0),
            name: reader.GetString(1),
            description: reader.IsDBNull(2) ? null : reader.GetString(2),
            price: reader.GetDecimal(3),
            stockQuantity: reader.GetInt32(4),
            createdAt: reader.GetDateTime(5));
    }

    public async Task<Product?> FindByNameAsync(string name)
    {
        const string sql = """"
            SELECT id, name, description, price, stock_quantity, created_at
            FROM products
            WHERE LOWER(name) = LOWER(@name);
            """";

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@name", name);

        await using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        return Product.Restore(
            id: reader.GetInt64(0),
            name: reader.GetString(1),
            description: reader.IsDBNull(2) ? null : reader.GetString(2),
            price: reader.GetDecimal(3),
            stockQuantity: reader.GetInt32(4),
            createdAt: reader.GetDateTime(5));
    }

    public async Task<List<Product>> FindManyAsync(int pageNumber, int pageSize, string? searchTerm = null)
    {
        var hasSearchTerm = !string.IsNullOrWhiteSpace(searchTerm);
        var offset = (pageNumber - 1) * pageSize;

        var sql = hasSearchTerm ? """
            SELECT id, name, description, price, stock_quantity, created_at
            FROM products
            WHERE name ILIKE @search_term
            ORDER BY name ASC, id ASC
            LIMIT @page_size
            OFFSET @offset;
            """
            : """
            SELECT id, name, description, price, stock_quantity, created_at
            FROM products
            ORDER BY name ASC, id ASC
            LIMIT @page_size
            OFFSET @offset;
            """;

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);

        if (searchTerm is not null)
            command.Parameters.AddWithValue("@search_term", $"%{searchTerm.Trim()}%");

        command.Parameters.AddWithValue("@page_size", pageSize);
        command.Parameters.AddWithValue("@offset", offset);

        await using var reader = await command.ExecuteReaderAsync();

        var products = new List<Product>();

        while (await reader.ReadAsync())
        {
            var product = Product.Restore(
                id: reader.GetInt64(0),
                name: reader.GetString(1),
                description: reader.IsDBNull(2) ? null : reader.GetString(2),
                price: reader.GetDecimal(3),
                stockQuantity: reader.GetInt32(4),
                createdAt: reader.GetDateTime(5));

            products.Add(product);
        }

        return products;
    }

    public async Task SaveAsync(Product product)
    {
        const string sql = """
            UPDATE products
            SET name = @name, description = @description, price = @price, stock_quantity = @stock_quantity
            WHERE id = @id;
            """;

        await using var connection = _connectionFactory.CreateConnection();
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", product.Id);
        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@description", product.Description is null ? DBNull.Value : product.Description);
        command.Parameters.AddWithValue("@price", product.Price);
        command.Parameters.AddWithValue("@stock_quantity", product.StockQuantity);

        await command.ExecuteNonQueryAsync();
    }
}
