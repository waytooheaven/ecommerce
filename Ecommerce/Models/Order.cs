namespace Ecommerce.Models;
public sealed class Order : Base
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public Customer? Customer { get; set; }
}
