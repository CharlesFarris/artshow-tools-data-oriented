using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="Inventory"/>.
/// </summary>
internal static class InventoryTests
{
    [Test]
    public static void GetMediumById_ValidatesBehavior()
    {
        var record = Inventory.GetMediumById(TestData, "1160A622-2820-4C43-B66B-660B99F8E485");
        Assert.That(record, Is.Not.Null);
        Assert.That(record!.GetValueOrDefault("name"), Is.EqualTo("None"));
    }

    private static readonly ImmutableDictionary<string, object> TestData = Generic
        .BeginRecord()
        .AddProperty("mediumsById", Generic.BeginRecordIndex()
            .Add("1160A622-2820-4C43-B66B-660B99F8E485", Generic
                .BeginRecord()
                .AddProperty("name", "None")
                .End())
            .Add("A3511250-FF17-48A5-8988-7153DF0CE8C2", Generic
                .BeginRecord()
                .AddProperty("name", "Pencil")
                .End())
            .Add("1D0DAEED-30FB-4D1B-8A69-154C41375CC9", Generic
                .BeginRecord()
                .AddProperty("name", "Acrylic")
                .End())
            .Add("1B2F4A7A-1B1E-4462-8963-4E351C65156F", Generic
                .BeginRecord()
                .AddProperty("name", "Marble")
                .End())
            .End())
        .AddProperty("artworksById", Generic
            .BeginRecordIndex()
            .Add("A96B3588-3AFE-4E20-95C6-9896D188E157", Generic
                .BeginRecord()
                .AddProperty("title", "A Study in Green")
                .AddProperty("mediumId", "1D0DAEED-30FB-4D1B-8A69-154C41375CC9")
                .End())
            .Add("C2F8B1FA-8585-49AA-B26F-51080D3FF145", Generic
                .BeginRecord()
                .AddProperty("title", "Bowl of Fruit")
                .AddProperty("mediumId", "A3511250-FF17-48A5-8988-7153DF0CE8C2")
                .End())
            .End())
        .End();
}
