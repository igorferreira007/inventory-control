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

    private Product(string name, string? description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = 0;
        CreatedAt = DateTime.UtcNow;
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

    public static Product Create(string name, string? description, decimal price)
    {
        ValidateName(name);
        ValidatePrice(price);

        return new Product(name, description, price);
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
}
