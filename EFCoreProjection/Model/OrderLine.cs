namespace EFCoreProjection.Model
{
    public class OrderLine
    {
        public record OrderLineId(int Value) : EntityId<int>(Value);

        public OrderLineId Id { get; set; }
        public Product.ProductId ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
