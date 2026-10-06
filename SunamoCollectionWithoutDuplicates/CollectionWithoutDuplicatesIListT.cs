namespace SunamoCollectionWithoutDuplicates;

public class CollectionWithoutDuplicatesIListT<T> : CollectionWithoutDuplicatesBaseIList<T>
{
    public override int AddWithIndex(T value)
    {
        var index = Collection.IndexOf(value);
        if (index == -1)
        {
            Add(value);
            return Collection.Count - 1;
        }
        return index;
    }

    public override bool? ContainsN(T value)
    {
        if (!Collection.Contains(value))
        {
            if (EqualityComparer<T>.Default.Equals(value, default))
                return null;
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns the zero-based index of the specified item in the collection using default equality comparison.
    /// </summary>
    /// <param name="value">The item to find.</param>
    /// <returns>The zero-based index of the item, or -1 if the item is not found.</returns>
    public override int IndexOf(T value) => Collection.IndexOf(value);

    /// <summary>
    /// Determines whether this collection compares items by their string representation.
    /// Always returns false because this class uses default equality comparison.
    /// </summary>
    /// <returns>Always returns false.</returns>
    protected override bool IsComparingByString() => false;
}
