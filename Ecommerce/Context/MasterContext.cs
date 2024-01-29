using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context;

public sealed class MasterContext : DatabaseContext
{
    public MasterContext(DbContextOptions<MasterContext> options) : base(options)
    {
    }

    //the main idea of this wrapper is to add more functionality like a method here, this is open to extension closed to modification principle of SOLID
}
