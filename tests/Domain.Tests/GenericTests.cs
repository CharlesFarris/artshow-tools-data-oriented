﻿using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain.Tests;

/// <summary>
/// Tests for <see cref="Generic" />.
/// </summary>
internal static class GenericTests
{
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

    [Test]
    public static void Get_ValidatesBehavior()
    {
        // use case #1
        {
            var result = Generic.Get(TestData, "mediumsById", "1160A622-2820-4C43-B66B-660B99F8E485");
            Assert.That(result, Is.TypeOf<ImmutableDictionary<string, object>>());
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

    [Test]
    public static void BeginRecord_ValidatesBehavior()
    {
        var builder = Generic.BeginRecord();
        Assert.That(builder, Is.Not.Null);
        var record = builder.End();
        Assert.That(record, Is.InstanceOf<ImmutableDictionary<string, object>>());
        Assert.That(record, Is.Empty);
    }

    [Test]
    public static void BeginRecordIndex_ValidatesBehavior()
    {
        var builder = Generic.BeginRecordIndex();
        Assert.That(builder, Is.Not.Null);
        var index = builder.End();
        Assert.That(index, Is.InstanceOf<ImmutableDictionary<string, object>>());
        Assert.That(index, Is.Empty);
    }

    [Test]
    public static void BeginCollection_ValidatesBehavior()
    {
        var builder = Generic.BeginCollection();
        Assert.That(builder, Is.Not.Null);
        var collection = builder.End();
        Assert.That(collection, Is.InstanceOf<ImmutableList<object>>());
        Assert.That(collection, Is.Empty);
    }

    [Test]
    public static void BeginIndex_ValidatesBehavior()
    {
        var builder = Generic.BeginIndex<string>();
        Assert.That(builder, Is.Not.Null);
        var index = builder.End();
        Assert.That(index, Is.InstanceOf<ImmutableDictionary<string, object>>());
        Assert.That(index, Is.Empty);
    }
}
