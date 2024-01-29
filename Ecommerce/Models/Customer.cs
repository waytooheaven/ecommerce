namespace Ecommerce.Models;
public sealed class Customer : Base
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Address { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
