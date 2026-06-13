namespace InventoryControl.Application.interfaces;

public interface IProductService
{
    Task CreateProduct(string name, string? description, decimal price, int stockQuantity);
}
