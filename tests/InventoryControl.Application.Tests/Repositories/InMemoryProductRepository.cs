using InventoryControl.Application.Interfaces;
using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Tests.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    public List<Product> Products { get; } = [];

    public Task CreateAsync(Product product)
    {
        Products.Add(product);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> FindByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> FindByNameAsync(string name)
    {
        var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(product);
    }

    public Task<Product[]> FindManyAsync(int pageNumber)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
