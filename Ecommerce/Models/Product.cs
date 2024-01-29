namespace Ecommerce.Models;
public class Product : Base
{
    public int Stock { get; set; }
    public string? Name { get; set; }
    public string? Sku { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
