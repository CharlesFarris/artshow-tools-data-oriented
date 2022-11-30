using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Helper methods for creating indices, records, and collections.
/// </summary>
public static class Generic
{
    /// <summary>
    /// Creates a heterogeneous map for containing a index.
    /// </summary>
    /// <typeparam name="TId">The type of the ID.</typeparam>
    public static ImmutableDictionary<TId, ImmutableDictionary<string, object>> CreateIndex<TId>()
        where TId : notnull
        => ImmutableDictionary<TId, ImmutableDictionary<string, object>>.Empty;

    /// <summary>
    /// Creates a generic data structure containing a record.
    /// </summary>
    public static ImmutableDictionary<string, object> CreateRecord() =>
        ImmutableDictionary<string, object>.Empty;

    /// <summary>
    /// Gets the value using the supplied path.
    /// </summary>
    public static object Get(object data, IEnumerable<string> path) =>
        path.Aggregate(data, (current, key) => ((ImmutableDictionary<string, object>)current)[key]);

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
    /// Check if a value exists using the supplied path.
    /// </summary>
    public static bool Exists(object data, params string[] path)
    {
        var result = data;
        foreach (var key in path)
        {
            if (result is not ImmutableDictionary<string, object> record)
            {
                return false;
            }

            if (!record.TryGetValue(key, out var value))
            {
                return false;
            }

            result = value;
        }

        return true;
    }

    public static RecordBuilder BeginRecord() => new RecordBuilder();
    public static IndexBuilder<T> BeginIndex<T>() => new IndexBuilder<T>();
    public static IndexBuilder<ImmutableDictionary<string, object>> BeginRecordIndex() => new();
    public static CollectionBuilder BeginCollection() => new CollectionBuilder();
}
