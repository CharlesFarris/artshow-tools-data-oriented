using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Fluent builder for an "index".
/// </summary>
/// <typeparam name="T">The homogenous type stored in the index.</typeparam>
public sealed class IndexBuilder<T>
{
    private ImmutableDictionary<string, object> _record = ImmutableDictionary<string, object>.Empty;

    internal IndexBuilder()
    {
    }

    /// <summary>
    /// Adds a value to the index.
    /// </summary>
    public IndexBuilder<T> Add(string key, T value)
    {
        this._record = this._record.Add(key, value!);
        return this;
    }

    /// <summary>
    /// Ends the fluent chain and returns the "index".
    /// </summary>
    public ImmutableDictionary<string, object> End() => this._record;
}
