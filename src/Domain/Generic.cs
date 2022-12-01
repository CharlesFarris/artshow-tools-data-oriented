using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Helper methods for creating indices, records, and collections.
/// </summary>
public static class Generic
{
    /// <summary>
    /// Gets the value using the supplied path.
    /// </summary>
    public static object Get(object data, params string[] path) =>
        path.Aggregate(data, (current, key) => ((ImmutableDictionary<string, object>)current)[key]);

    /// <summary>
    /// Maps the values of a collection.
    /// </summary>
    public static IEnumerable<object> Map(IEnumerable<object> data, Func<object, object> mapFunc) =>
        data.Select(mapFunc);

    /// <summary>
    /// Filters the value of collection
    /// </summary>
    public static IEnumerable<object> Filter(IEnumerable<object> data, Func<object, bool> predicate) =>
        data.Where(predicate);

    /// <summary>
    /// Check if a value exists using the supplied path.
    /// </summary>
    public static bool Exists(object data, params string[] path)
    {
        var result = data;
        foreach (var key in path)
        {
            if (result is not ImmutableDictionary<string, object> record) return false;

            if (!record.TryGetValue(key, out var value)) return false;

            result = value;
        }

        return true;
    }

    /// <summary>
    /// Fluent method for building a record.
    /// </summary>
    public static RecordBuilder BeginRecord() => new();

    /// <summary>
    /// Fluent method for building an index.
    /// </summary>
    public static IndexBuilder<T> BeginIndex<T>() => new();

    /// <summary>
    /// Fluent method for building an index of records.
    /// </summary>
    public static IndexBuilder<ImmutableDictionary<string, object>> BeginRecordIndex() => new();

    /// <summary>
    /// Fluent method for building a collection.
    /// </summary>
    public static CollectionBuilder BeginCollection() => new();
}
