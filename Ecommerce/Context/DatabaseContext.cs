﻿using Ecommerce.Configurations;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }
    protected DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    }
}
