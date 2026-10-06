namespace SunamoCollectionWithoutDuplicates;

public class CollectionWithoutDuplicatesStringComparing<T> : CollectionWithoutDuplicatesBase<T>
{
    public CollectionWithoutDuplicatesStringComparing()
    {
    }

    public CollectionWithoutDuplicatesStringComparing(int initialCapacity) : base(initialCapacity)
    {
    }

    public CollectionWithoutDuplicatesStringComparing(IList<T> list) : base(list)
    {
    }

    public override int AddWithIndex(T value)
    {
        if (Contains(value).GetValueOrDefault())
        {
            return StringRepresentations.IndexOf(value?.ToString()!);
        }

        Add(value);
        return Collection.Count - 1;
    }

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