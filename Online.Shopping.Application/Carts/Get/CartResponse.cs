namespace Online.Shopping.Application.Carts.Get;

public record CartResponse(Guid Id, Guid CustomerId, List<LineItemResponse> LineItems);