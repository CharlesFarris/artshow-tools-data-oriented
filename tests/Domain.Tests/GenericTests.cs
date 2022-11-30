using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="Generic"/>.
/// </summary>
internal static class GenericTests
{
    [Test]
    public static void Get_ValidatesBehavior()
    {
        // use case #1
        {
            var result = Generic.Get(TestData, "mediumsById", "1160A622-2820-4C43-B66B-660B99F8E485");
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() => { Assert.That(result, Is.TypeOf<ImmutableDictionary<string, object>>()); });
        }

        // use case #2
        {
            var result = Generic.Get(TestData, "mediumsById", "1160A622-2820-4C43-B66B-660B99F8E485", "name");
            Assert.That(result, Is.EqualTo("None"));
        }
    }

    [Test]
    public static void Exists_ValidatesBehavior()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Generic.Exists(TestData, "artworksById"), Is.True);
            Assert.That(Generic.Exists(TestData, "notExists"), Is.False);
        });
    }

    [Test]
    public static void Map_ValidatesBehavior()
    {
        var collection = Generic.BeginCollection()
            .Add("A", "B", "C", "D")
            .End();
        var result = Generic.Map(collection, value => ((string)value).ToLowerInvariant());
        CollectionAssert.AreEqual(new[] { "a", "b", "c", "d" }, result);
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
