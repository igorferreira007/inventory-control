namespace InventoryControl.Application.DTOs;

public record CreateProductRequestDto(string Name, decimal Price, string? Description);
