using System.Collections.Immutable;

namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Module containing methods related to inventory management.
/// </summary>
public static class Inventory
{
    /// <summary>
    /// Gets a medium record by ID.
    /// </summary>
    public static ImmutableDictionary<string, object>? GetMediumById(object data, string id) =>
        Generic.Get(data, "mediumsById", id) as ImmutableDictionary<string, object>;
}
