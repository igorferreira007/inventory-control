namespace InventoryControl.Application.DTOs;

public record DecreaseProductStockRequestDto(long ProductId, int Quantity);
