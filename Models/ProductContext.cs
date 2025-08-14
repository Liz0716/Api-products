using System;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Models;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {

    }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrdersItem> OrderItem { get; set; }
    
      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Rol>().HasData(
            new Rol { Id = 1, Name = "Admin" }
        );
    }

}
