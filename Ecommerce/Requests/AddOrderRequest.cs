namespace Ecommerce.Requests;
public sealed record AddOrderRequest(int CustomerId, int ProductId);