using System;
using System.Collections.Generic;

namespace EFCoreProjection.Model
{
    public class Order
    {
        public record OrderId(Guid Value) : EntityId<Guid>(Value);

        public record OrderData(DateTime Timestamp);

        public OrderId Id { get; set; }
        public OrderData Data { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
