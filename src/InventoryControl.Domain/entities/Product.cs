using InventoryControl.Domain.Exceptions;

namespace InventoryControl.Domain.Entities;

public class Product
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Product(string name, decimal price, string? description = null)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = 0;
        CreatedAt = DateTime.UtcNow;
    }

    private Product(long id, string name, decimal price, int stockQuantity, DateTime createdAt, string? description = null)
        : this(name, price, description)
    {
        Id = id;
        StockQuantity = stockQuantity;
        CreatedAt = createdAt;
    }

    public static Product Create(string name, decimal price, string? description = null)
    {
        ValidateName(name);
        ValidatePrice(price);

        return new Product(name, price, description);
    }

    public static Product Restore(long id, string name, decimal price, int stockQuantity, DateTime createdAt, string? description = null)
    {
        ValidateId(id);
        ValidateName(name);
        ValidatePrice(price);
        ValidateStockQuantity(stockQuantity);

        return new Product(id, name, price, stockQuantity, createdAt, description);
    }

    public void AssignId(long id)
    {
        if (Id != 0)
            throw new DomainException("O ID do produto já foi definido.");

        ValidateId(id);

        Id = id;
    }

    public void ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void ChangeDescription(string? description)
    {
        Description = description;
    }

    public void ChangePrice(decimal price)
    {
        ValidatePrice(price);
        Price = price;
    }

    public void IncreaseStock(int quantity)
    {
        ValidateQuantity(quantity);
        StockQuantity += quantity;
    }

    public void DecreaseStock(int quantity)
    {
        ValidateQuantity(quantity);

        if (quantity > StockQuantity)
            throw new DomainException("Não há estoque suficiente para remover a quantidade solicitada.");

        StockQuantity -= quantity;
    }

    private static void ValidateId(long id)
    {
        if (id <= 0)
            throw new DomainException("O ID do produto deve ser maior que zero.");
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("O nome não pode ser vazio.");
    }

    private static void ValidatePrice(decimal price)
    {
        if (price <= 0)
            throw new DomainException("O preço deve ser maior que zero.");
    }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new DomainException("A quantidade deve ser maior que zero.");
    }

    private static void ValidateStockQuantity(int stockQuantity)
    {
        if (stockQuantity < 0)
            throw new DomainException("A quantidade em estoque não pode ser negativa.");
    }
}
