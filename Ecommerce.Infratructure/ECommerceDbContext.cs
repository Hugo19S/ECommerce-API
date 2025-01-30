using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;

namespace Ecommerce.Infratructure;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext() { }
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> option) : base(option) { }

    public DbSet<Cart> Cart { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Maker> Maker { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<OrderStatusHistory> OrderStatusHistory { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<PaymentMethod> PaymentMethod { get; set; }
    public DbSet<PaymentStatusHistory> PaymentStatusHistory { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductDiscount> ProductDiscount { get; set; }
    public DbSet<ProductImage> ProductImage { get; set; }
    public DbSet<ProductPrice> ProductPrice { get; set; }
    public DbSet<Seller> Seller { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<SubCategory> SubCategory { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../Ecommerce.Service"));
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("ECommerce");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
