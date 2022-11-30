using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Fluent builder used to create a "collection".
/// </summary>
public sealed class CollectionBuilder
{
    private ImmutableList<object> _collection = ImmutableList<object>.Empty;

    internal CollectionBuilder()
    {
    }

    /// <summary>
    /// Adds a value to the "collection".
    /// </summary>
    public CollectionBuilder Add(object value)
    {
        this._collection = this._collection.Add(value);
        return this;
    }

    /// <summary>
    /// Adds multiple values to the "collection".
    /// </summary>
    public CollectionBuilder Add(params object[] values)
    {
        this._collection = this._collection.AddRange(values);
        return this;
    }

    /// <summary>
    /// Ends the fluent chain and returns back the "collection".
    /// </summary>
    /// <returns></returns>
    public ImmutableList<object> End() => this._collection;
}
