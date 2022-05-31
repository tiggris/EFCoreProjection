namespace EFCoreProjection.Model
{
    public class Product
    {
        public record ProductId(string Value) : EntityId<string>(Value);
    }
}
