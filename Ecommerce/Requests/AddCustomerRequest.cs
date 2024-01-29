namespace Ecommerce.Requests;
public sealed record AddCustomerRequest(string? Name, string? Surname, string? City, string? Province, string? Address);
