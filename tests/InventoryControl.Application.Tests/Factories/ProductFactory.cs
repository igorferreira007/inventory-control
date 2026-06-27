using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Tests.Factories;

public class ProductFactory
{
    public static Product Create(
        long id = 1,
        string? name = null,
        string? description = null,
        decimal price = 10.99m,
        int stockQuantity = 10,
        DateTime? createdAt = null)
    {
        name ??= $"Product test {id}";
        description ??= $"Product description test {id}.";

        return Product.Restore(
            id,
            name,
            price,
            stockQuantity,
            createdAt ?? DateTime.UtcNow,
            description);
    }
}
