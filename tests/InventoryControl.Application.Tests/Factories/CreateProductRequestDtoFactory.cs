using InventoryControl.Application.DTOs;

namespace InventoryControl.Application.Tests.Factories;

public static class CreateProductRequestDtoFactory
{
    public static CreateProductRequestDto Create(string name = "Test Product", decimal price = 10.99m, string? description = "This is a test product.")
    {
        return new CreateProductRequestDto(name, price, description);
    }
}
