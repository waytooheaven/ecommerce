namespace Ecommerce.Models;
public sealed class Product : Base
{
    public int Stock { get; set; }
    public string? Name { get; set; }
    public string? Sku { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
