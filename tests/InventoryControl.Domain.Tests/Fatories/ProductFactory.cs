using InventoryControl.Domain.Entities;

namespace InventoryControl.Domain.Tests.Fatories;

public static class ProductFactory
{
    public static Product Create(string name = "Test Product", decimal price = 10.99m, string? description = "This is a test product.")
    {
        return Product.Create(name, price, description);
    }
}
