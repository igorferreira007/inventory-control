using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Interfaces;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<Product?> FindByIdAsync(long id);
    Task<Product?> FindByNameAsync(string name);
    Task<Product[]> FindManyAsync(int pageNumber);
    Task SaveAsync(Product product);
    Task DeleteAsync(Product product);
}
