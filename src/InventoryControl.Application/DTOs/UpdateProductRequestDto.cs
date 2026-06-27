namespace InventoryControl.Application.DTOs;

public record UpdateProductRequestDto(long ProductId, string Name, decimal Price, string? Description);
