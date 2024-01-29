using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context;

public class MasterContext : DatabaseContext
{
    public MasterContext(DbContextOptions<MasterContext> options) : base(options)
    {
    }
}
