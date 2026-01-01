namespace SunamoCollectionWithoutDuplicates._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.

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
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();

    /// <summary>
    /// StringBuilder for building additional information for exceptions.
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();

    #endregion

    #endregion
}
