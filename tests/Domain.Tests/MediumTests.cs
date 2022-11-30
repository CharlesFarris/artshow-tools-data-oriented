namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="Medium"/>.
/// </summary>
internal static class Tests
{
    [Test]
    public static void Ctor_ValidatesBehavior()
    {
        var medium = new Medium();
        Assert.That(medium, Is.Not.Null);
    }
}
