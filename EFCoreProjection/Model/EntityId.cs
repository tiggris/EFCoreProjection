namespace EFCoreProjection.Model
{
    public abstract record EntityId<T>
    {
        public T Value { get; protected set; }

        protected EntityId(T value) => Value = value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator T(EntityId<T> entityId) => entityId.Value;
    }
}
