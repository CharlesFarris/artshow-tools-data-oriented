using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Fluent builder for a "record".
/// </summary>
public sealed class RecordBuilder
{
    internal RecordBuilder()
    {
    }

    /// <summary>
    /// Adds a property to a record.
    /// </summary>
    public RecordBuilder AddProperty(string key, object value)
    {
        this._record = this._record.Add(key, value);
        return this;
    }

    /// <summary>
    /// End the fluent chain and returns the "record".
    /// </summary>
    public ImmutableDictionary<string, object> End() => this._record;

    private ImmutableDictionary<string, object> _record = ImmutableDictionary<string, object>.Empty;
}
