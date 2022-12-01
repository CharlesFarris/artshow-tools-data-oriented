namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="IndexBuilder{T}"/>.
/// </summary>
internal static class IndexBuilderTests
{
    [Test]
    public static void Add_ValidatesBehavior()
    {
        var index = Generic.BeginIndex<string>()
            .Add("a", "abc")
            .Add("b", "def")
            .End();
        Assert.Multiple(() =>
        {
            Assert.That(index.GetValueOrDefault("a"), Is.EqualTo("abc"));
            Assert.That(index.GetValueOrDefault("b"), Is.EqualTo("def"));
            Assert.That(index.GetValueOrDefault("c"), Is.Null);
        });
    }
}
