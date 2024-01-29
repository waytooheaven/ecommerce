namespace Ecommerce.Requests;

public sealed record ReportingRequest(DateTime? CreateDateStart, DateTime? CreateDateEnd, string? Name, string? Surname);
