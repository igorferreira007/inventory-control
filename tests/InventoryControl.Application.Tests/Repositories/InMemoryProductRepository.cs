using InventoryControl.Application.Interfaces;
using InventoryControl.Domain.Entities;

namespace InventoryControl.Application.Tests.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private long _currentId = 1;

    public List<Product> Products { get; } = [];

    public void Add(Product product)
    {
        Products.Add(product);

        if (product.Id >= _currentId)
            _currentId = product.Id + 1;
    }

    public Task CreateAsync(Product product)
    {
        if (product.Id == 0)
            product.AssignId(_currentId++);

        Products.Add(product);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        int productIndex = Products.FindIndex(p => p.Id == product.Id);

        Products.RemoveAt(productIndex);

        return Task.CompletedTask;
    }

    public Task<Product?> FindByIdAsync(long id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);

        return Task.FromResult(product);
    }

    public Task<Product?> FindByNameAsync(string name)
    {
        var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(product);
    }

    public Task<List<Product>> FindManyAsync(int pageNumber, int pageSize, string? searchTerm = null)
    {
        IEnumerable<Product> query = Products;

        if (searchTerm is not null)
            query = query.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));      

        var products = query.OrderBy(p => p.Name).Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();

        return Task.FromResult(products);
    }

    public Task SaveAsync(Product product)
    {
        int productIndex = Products.FindIndex(p => p.Id == product.Id);

        Products[productIndex] = product;

        return Task.CompletedTask;
    }
}
