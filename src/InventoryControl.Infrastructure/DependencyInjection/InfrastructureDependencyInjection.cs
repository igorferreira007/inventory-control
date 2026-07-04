using InventoryControl.Application.Interfaces;
using InventoryControl.Infrastructure.Database;
using InventoryControl.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryControl.Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddSingleton(_ =>
            new PostgresConnectionFactory(connectionString));

        services.AddScoped<IProductRepository, PostgresProductRepository>();

        return services;
    }
}
