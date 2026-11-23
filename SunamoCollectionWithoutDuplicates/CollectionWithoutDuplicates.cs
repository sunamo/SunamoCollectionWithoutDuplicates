namespace SunamoCollectionWithoutDuplicates;

/// <summary>
/// Represents the collection without duplicates t type.
/// </summary>
public class CollectionWithoutDuplicates<T> : CollectionWithoutDuplicatesBase<T>
{
    /// <summary>
    /// Initializes a new instance of the collection without duplicates class.
    /// </summary>
    public CollectionWithoutDuplicates()
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates class.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity.</param>
    public CollectionWithoutDuplicates(int initialCapacity) : base(initialCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates class.
    /// </summary>
    /// <param name="list">The list.</param>
    public CollectionWithoutDuplicates(IList<T> list) : base(list)
    {
    }

    /// <summary>
    /// Add with index.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The add with index result.</returns>
    public override int AddWithIndex(T value)
    {
        if (IsComparingByString())
        {
            if (!Contains(value).GetValueOrDefault())
            {
                Add(value);
                return Collection.Count - 1;
            }
        }

        var index = Collection.IndexOf(value);
        if (index == -1)
        {
            Add(value);
            return Collection.Count - 1;
        }

        return index;
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The contains result.</returns>
    public override bool? Contains(T value)
    {
        if (IsComparingByString())
        {
            StringValue = value?.ToString();
            return StringRepresentations.Contains(StringValue!);
        }

        if (!Collection.Contains(value))
        {
            if (EqualityComparer<T>.Default.Equals(value, default)) return null;
            return false;
        }

        return true;
    }

    /// <summary>
    /// Index of.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The index of result.</returns>
    public override int IndexOf(T value)
    {
        if (IsComparingByString()) return StringRepresentations.IndexOf(value?.ToString()!);
        var index = Collection.IndexOf(value);
        if (index == -1)
        {
            Collection.Add(value);
            return Collection.Count - 1;
        }

        return index;
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    /// <returns>The is comparing by string result.</returns>
    protected override bool IsComparingByString()
    {
        return AllowNull.HasValue && AllowNull.Value;
    }
}
