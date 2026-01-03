namespace SunamoCollectionWithoutDuplicates._sunamo.SunamoArgs;

/// <summary>
/// Arguments for controlling dump-as-string behavior.
/// Must be in SunamoArgs because it is shared between SunamoReflection and SunamoCollectionWithoutDuplicates.
/// </summary>
internal class DumpAsStringHeaderArgs
{
    /// <summary>
    /// Gets the default instance of dump-as-string arguments.
    /// </summary>
    internal static DumpAsStringHeaderArgs Default = new();

    /// <summary>
    /// Only names of properties to get.
    /// If starting with ! then surely delete.
    /// </summary>
    internal List<string> OnlyNames = new();
}