namespace Ecommerce.Models;
public class Base
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
