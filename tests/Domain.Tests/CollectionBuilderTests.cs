namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="CollectionBuilder"/>.
/// </summary>
internal static class CollectionBuilderTests
{
    [Test]
    public static void Add_ValidatesBehavior()
    {
        var collection = Generic.BeginCollection()
            .Add("a")
            .Add("b")
            .Add("c")
            .End();
        Assert.That(collection, Is.EqualTo(new[] { "a", "b", "c" }));
    }

    [Test]
    public static void AddRange_ValidatesBehavior()
    {
        var collection = Generic.BeginCollection()
            .Add("a", "b", "c", "d")
            .End();
        Assert.That(collection, Is.EqualTo(new[] { "a", "b", "c", "d" }));
    }
}
