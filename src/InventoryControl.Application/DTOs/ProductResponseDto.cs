namespace InventoryControl.Application.DTOs;

public record ProductResponseDto(
    long Id,
    string Name,
    decimal Price,
    int StockQuantity,
    string? Description,
    DateTime CreatedAt);
