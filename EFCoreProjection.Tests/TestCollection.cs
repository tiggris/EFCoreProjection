using EFCoreProjection.Tests.Utils;

namespace EFCoreProjection.Tests
{
    [CollectionDefinition("Projection test collection")]
    public class TestCollection : ICollectionFixture<DatabaseFixture>
    {
    }
}
