namespace SunamoCollectionWithoutDuplicates._sunamo.SunamoExceptions;

/// <summary>
/// Helper class for building exception messages with additional information.
/// </summary>
internal sealed partial class Exceptions
{
    #region Other

    #region IsNullOrWhitespace

    /// <summary>
    /// StringBuilder for building inner additional information for exceptions.
    /// </summary>
    internal static StringBuilder AdditionalInfoInnerStringBuilder { get; } = new();

    /// <summary>
    /// StringBuilder for building additional information for exceptions.
    /// </summary>
    internal static StringBuilder AdditionalInfoStringBuilder { get; } = new();

    #endregion

    #endregion
}