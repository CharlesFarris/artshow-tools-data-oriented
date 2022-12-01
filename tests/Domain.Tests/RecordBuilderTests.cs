namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="RecordBuilder"/>.
/// </summary>
internal static class RecordBuilderTests
{
    [Test]
    public static void Add_ValidatesBehavior()
    {
        var record = Generic.BeginRecord()
            .AddProperty("a", 123)
            .AddProperty("b", "def")
            .End();
        Assert.Multiple(() =>
        {
            Assert.That(record.GetValueOrDefault("a"), Is.EqualTo(123));
            Assert.That(record.GetValueOrDefault("b"), Is.EqualTo("def"));
        });
    }
}
