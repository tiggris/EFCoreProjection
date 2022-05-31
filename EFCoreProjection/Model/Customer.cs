using System;

namespace EFCoreProjection.Model
{
    public class Customer
    {
        public record CustomerId(Guid Value) : EntityId<Guid>(Value);

        public record CustomerName(string FirstName, string LastName);

        public CustomerName Name { get; set; }
    }
}