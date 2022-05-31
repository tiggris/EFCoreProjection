using EFCoreProjection.Data;
using EFCoreProjection.Model;
using EFCoreProjection.Tests.Utils;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProjection.Tests
{
    [Collection("Projection test collection")]
    public class ProjectionTests
    {
        [Fact]
        public void QueryOrderLines_WhenUsingProjection_ShouldNotThrowException()
        {
            // Arrange
            var order = new Order
            {
                Id = new Order.OrderId(Guid.NewGuid()),
                Data = new Order.OrderData(DateTime.UtcNow),
                OrderLines = new HashSet<OrderLine>
                {
                    new OrderLine {
                        Id = new OrderLine.OrderLineId(1),
                        ProductId = new Product.ProductId("abc"),
                        Quantity = 2,
                        TotalPrice = 10
                    },
                    new OrderLine {
                        Id = new OrderLine.OrderLineId(2),
                        ProductId = new Product.ProductId("xyz"),
                        Quantity = 1,
                        TotalPrice = 25
                    }
                }
            };

            // Act
            using (var dataContext = new DataContext(DatabaseFixture.DbContextOptions))
            {
                dataContext.Orders.Add(order);
                dataContext.SaveChanges();
            }

            // Assert
            using (var dataContext = new DataContext(DatabaseFixture.DbContextOptions))
            {
                var orderLines = dataContext.Orders
                    .SelectMany(order => order.OrderLines.Select(orderLine => new { OrderLine = orderLine, Order = order }))
                    .AsNoTracking()
                    .ToList();
                Assert.NotNull(orderLines);
            }
        }
    }
}