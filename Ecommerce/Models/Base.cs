namespace Ecommerce.Models;
//DRY, don't repeat yourself
public abstract class Base
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
}
