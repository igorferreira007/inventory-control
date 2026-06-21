using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Interfaces;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task<Product?> FindByIdAsync(long id);
    Task<Product?> FindByNameAsync(string name);
    Task<List<Product>> FindManyAsync(int pageNumber, int pageSize, string? searchTerm = null);
    Task SaveAsync(Product product);
    Task DeleteAsync(Product product);
}
