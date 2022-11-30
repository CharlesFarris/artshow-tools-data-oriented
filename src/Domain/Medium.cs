namespace SleepingBearSystems.ArtShowToolsDataOriented.Domain;

/// <summary>
/// Module containing methods related to mediums.
/// </summary>
public static class Medium
{
    /// <summary>
    /// Gets a medium record by ID.
    /// </summary>
    public static object GetMediumById(object data, string id)
    {
        return Generic.Get(data, "mediumsById", id);
    }
}
