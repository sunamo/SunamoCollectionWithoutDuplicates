// variables names: ok
namespace SunamoCollectionWithoutDuplicates._sunamo.SunamoInterfaces.Interfaces;

/// <summary>
/// Interface for objects that can be dumped as a string representation.
/// </summary>
internal interface IDumpAsString
{
    /// <summary>
    /// Dumps the object as a string representation.
    /// </summary>
    /// <param name="operation">The operation name.</param>
    /// <param name="dumpAsStringHeaderArgs">Arguments controlling the dump behavior.</param>
    /// <returns>A string representation of the object.</returns>
    string DumpAsString(string operation, object dumpAsStringHeaderArgs);
}