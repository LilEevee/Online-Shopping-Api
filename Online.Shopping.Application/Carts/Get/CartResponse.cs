namespace Online.Shopping.Application.Carts.Get;

public record CartResponse(Guid CartId, Guid CustomerId, List<LineItemResponse> LineItems);