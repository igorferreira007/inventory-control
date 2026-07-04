using FluentValidation;
using InventoryControl.Application.UseCases;
using InventoryControl.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryControl.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        //services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
        services.AddValidatorsFromAssembly(typeof(ApplicationDependencyInjection).Assembly,ServiceLifetime.Transient);

        services.AddTransient<CreateProductUseCase>();
        services.AddTransient<GetProductUseCase>();
        services.AddTransient<ListProductsUseCase>();
        services.AddTransient<UpdateProductUseCase>();
        services.AddTransient<DeleteProductUseCase>();
        services.AddTransient<IncreaseProductStockUseCase>();
        services.AddTransient<DecreaseProductStockUseCase>();

        return services;
    }
}
