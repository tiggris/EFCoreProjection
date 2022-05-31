using EFCoreProjection.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjection.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(order => order.Id).HasConversion(
                id => id.Value,
                id => new Order.OrderId(id));
            modelBuilder.Entity<Order>().HasMany(order => order.OrderLines).WithOne();
            modelBuilder.Entity<Order>().OwnsOne(order => order.Data, builder =>
            {
                builder.Property(data => data.Timestamp).IsRequired();
            })
            .Navigation(order => order.Data).IsRequired();            

            modelBuilder.Entity<OrderLine>().Property(orderLine => orderLine.Id).HasConversion(
                id => id.Value,
                id => new OrderLine.OrderLineId(id));
            modelBuilder.Entity<OrderLine>().Property(orderLine => orderLine.ProductId).HasConversion(
                id => id.Value,
                id => new Product.ProductId(id));

            base.OnModelCreating(modelBuilder);
        }
    }
}
