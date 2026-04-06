### SunamoCollectionWithoutDuplicates

A .NET collection that automatically prevents duplicate items. Supports both default equality comparison and string-based comparison.

Part of PlatformIndependentNuGetPackages:

- [nuget.org](https://www.nuget.org/profiles/sunamo)
- [github.org](https://github.com/sunamo/PlatformIndependentNuGetPackages)

Other links:

- [Developer site](https://sunamo.cz)

Request for new features / bug report / etc: [Mail](mailto:radek.jancik@sunamo.cz) or on GitHub

## Key Classes

- **CollectionWithoutDuplicates&lt;T&gt;** - Collection with duplicate prevention, supports both normal and string-based comparison modes.
- **CollectionWithoutDuplicatesStringComparing&lt;T&gt;** - Collection that always compares items by their string representation.
- **CollectionWithoutDuplicatesIListT&lt;T&gt;** - Collection implementing `IList<T>` with duplicate prevention using default equality.

## Key Methods

- `Add(T value)` - Adds an item if not already present.
- `AddWithIndex(T value)` - Adds an item and returns its index.
- `AddRange(IList<T> list)` - Adds multiple items, returns list of duplicates that were skipped.
- `Contains(T value)` / `ContainsN(T value)` - Checks if an item exists in the collection.
- `IndexOf(T value)` - Returns the index of an item.

## Installation

```bash
dotnet add package SunamoCollectionWithoutDuplicates
```

## Target Frameworks

**TargetFrameworks:** `net10.0;net9.0;net8.0`

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions**

## License

MIT - See the repository root for license information.
