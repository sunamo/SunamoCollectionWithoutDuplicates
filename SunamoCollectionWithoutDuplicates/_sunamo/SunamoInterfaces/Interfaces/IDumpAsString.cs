// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionWithoutDuplicates._sunamo.SunamoInterfaces.Interfaces;

internal interface IDumpAsString
{
    string DumpAsString(string operation, /*DumpAsStringHeaderArgs*/ object dumpAsStringHeaderArgs);
}