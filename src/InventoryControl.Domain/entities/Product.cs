namespace InventoryControl.Domain.entities;

public class Product
{
    private const string _invalidName = "O nome não pode ser vazio.";
    private const string _invalidPrice = "O preço não pode ser menor que zero.";
    private const string _invalidStockQuantity = "A quantidade em estoque não pode ser menor que zero.";

    public long Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    public Product(string name, string? description, decimal price, int stockQuantity)
    {
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public static Product Create(string name, string? description, decimal price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(_invalidName);

        if (price <= 0)
            throw new ArgumentException(_invalidPrice);

        if (stockQuantity <= 0)
            throw new ArgumentException(_invalidStockQuantity);

        return new Product(name, description, price, stockQuantity);
    }
}
