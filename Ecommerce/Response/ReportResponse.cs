using Ecommerce.Models;

namespace Ecommerce.Response;

public class ReportResponse
{
    public Customer? Customer { get; set; }
    public IEnumerable<Order>? Orders { get; set; } = new List<Order>();
}
