namespace InventoryControl.Application.DTOs;

public record IncreaseProductStockRequestDto(long ProductId, int Quantity);
