namespace InventoryControl.Application.DTOs;

public record ListProductsRequestDto(int PageNumber, int PageSize, string? SearchTerm = null);
