// variables names: ok
namespace SunamoCollectionWithoutDuplicates;

/// <summary>
/// A collection that automatically prevents duplicate items by comparing their string representations.
/// </summary>
/// <typeparam name="T">The type of items in the collection.</typeparam>
public class CollectionWithoutDuplicatesStringComparing<T> : CollectionWithoutDuplicatesBase<T>
{
    /// <summary>
    /// Initializes a new instance of the collection that compares items by their string representation.
    /// </summary>
    public CollectionWithoutDuplicatesStringComparing()
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection with a specified initial capacity.
    /// </summary>
    /// <param name="count">The initial capacity of the collection.</param>
    public CollectionWithoutDuplicatesStringComparing(int count) : base(count)
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection from an existing list.
    /// </summary>
    /// <param name="list">The list to initialize from.</param>
    public CollectionWithoutDuplicatesStringComparing(IList<T> list) : base(list)
    {
    }

    /// <summary>
    /// Adds an item to the collection and returns its index.
    /// If the item already exists (based on string comparison), returns the existing index.
    /// </summary>
    /// <param name="value">The item to add.</param>
    /// <returns>The index of the item in the collection.</returns>
    public override int AddWithIndex(T value)
    {
        if (Contains(value).GetValueOrDefault())
        {
            return StringRepresentations.IndexOf(value?.ToString()!);
        }

        Add(value);
        return Collection.Count - 1;
    }

    /// <summary>
    /// Determines whether the collection contains the specified item based on string comparison.
    /// </summary>
    /// <param name="value">The item to check.</param>
    /// <returns>True if the item exists, false otherwise.</returns>
    public override bool? Contains(T value)
    {
        StringValue = value?.ToString();
        return StringRepresentations.Contains(StringValue!);
    }

    /// <summary>
    /// Returns the index of the specified item based on string comparison.
    /// </summary>
    /// <param name="value">The item to find.</param>
    /// <returns>The zero-based index of the item.</returns>
    public override int IndexOf(T value)
    {
        return StringRepresentations.IndexOf(value?.ToString()!);
    }

    /// <summary>
    /// Determines whether the collection compares items by their string representation.
    /// </summary>
    /// <returns>Always returns true for this class.</returns>
    protected override bool IsComparingByString()
    {
        return true;
    }
}