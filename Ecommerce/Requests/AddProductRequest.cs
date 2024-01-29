namespace Ecommerce.Requests;
public sealed record AddProductRequest(int Stock, string? SKU, string? Name);
