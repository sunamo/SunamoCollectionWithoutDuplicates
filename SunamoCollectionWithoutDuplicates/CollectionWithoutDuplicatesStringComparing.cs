namespace SunamoCollectionWithoutDuplicates;

/// <summary>
/// Represents the collection without duplicates string comparing t type.
/// </summary>
public class CollectionWithoutDuplicatesStringComparing<T> : CollectionWithoutDuplicatesBase<T>
{
    /// <summary>
    /// Initializes a new instance of the collection without duplicates string comparing class.
    /// </summary>
    public CollectionWithoutDuplicatesStringComparing()
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates string comparing class.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity.</param>
    public CollectionWithoutDuplicatesStringComparing(int initialCapacity) : base(initialCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates string comparing class.
    /// </summary>
    /// <param name="list">The list.</param>
    public CollectionWithoutDuplicatesStringComparing(IList<T> list) : base(list)
    {
    }

    /// <summary>
    /// Add with index.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The add with index result.</returns>
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
    /// Contains.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The contains result.</returns>
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
    public override int IndexOf(T value) => StringRepresentations.IndexOf(value?.ToString()!);

    /// <summary>
    /// Determines whether the collection compares items by their string representation.
    /// </summary>
    /// <returns>Always returns true for this class.</returns>
    protected override bool IsComparingByString() => true;
}