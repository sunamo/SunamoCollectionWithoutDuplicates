namespace SunamoCollectionWithoutDuplicates;

/// <summary>
/// Base class for collections that automatically prevent duplicate items and implement IList interface.
/// </summary>
/// <typeparam name="T">The type of items in the collection.</typeparam>
public abstract class CollectionWithoutDuplicatesBaseIList<T> : IDumpAsString, IList<T>
{
    /// <summary>
    /// When true, breaks into debugger on construction. Used for debugging purposes.
    /// </summary>
    public static bool BreakOnConstruction = false;

    private bool? _allowNull = false;

    /// <summary>
    /// Gets or sets the underlying collection of items.
    /// </summary>
    public List<T> Collection { get; set; }

    private readonly int count = 10000;

    private bool resultOfAdd;

    /// <summary>
    /// Previously Contains() returned bool? but must comply with IList which requires bool.
    /// This property stores the nullable bool result.
    /// </summary>
    public bool? ResultOfBoolN { get; set; } = null;

    /// <summary>
    /// Gets or sets the string representations of items when comparing by string.
    /// </summary>
    public List<string> StringRepresentations { get; set; }

    /// <summary>
    /// The string value of the current item being processed.
    /// </summary>
    protected string? StringValue = null;

    private readonly List<T> wasNotAdded = new();

    /// <summary>
    /// Initializes a new instance of the collection without duplicates.
    /// </summary>
    public CollectionWithoutDuplicatesBaseIList()
    {
        if (BreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates with a specified initial capacity.
    /// </summary>
    /// <param name="count">The initial capacity of the collection.</param>
    public CollectionWithoutDuplicatesBaseIList(int count)
    {
        this.count = count;
        Collection = new List<T>(count);
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates from an existing list.
    /// </summary>
    /// <param name="list">The list to initialize from.</param>
    public CollectionWithoutDuplicatesBaseIList(IList<T> list)
    {
        Collection = new List<T>(list.ToList());
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Gets or sets whether to allow null values and how to compare items.
    /// True = compare items by their string representation.
    /// False = compare items normally (not by string).
    /// Null = allow null values (cannot compare by string).
    /// </summary>
    public bool? AllowNull
    {
        get => _allowNull;
        set
        {
            _allowNull = value;
            if (value.HasValue && value.Value) StringRepresentations = new List<string>(count);
        }
    }

    /// <summary>
    /// This method is not supported and will throw an exception.
    /// </summary>
    /// <param name="operation">The operation name.</param>
    /// <param name="dumpAsStringHeaderArgs">The dump arguments.</param>
    /// <returns>Never returns, always throws.</returns>
    /// <exception cref="Exception">Always thrown as this functionality has been moved to sunamo.</exception>
    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
    }

    /// <summary>
    /// Gets the number of items in the collection.
    /// </summary>
    public int Count => Collection.Count;

    /// <summary>
    /// Gets a value indicating whether the collection is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets or sets the item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to get or set.</param>
    /// <returns>The item at the specified index.</returns>
    public T this[int index]
    {
        get => Collection[index];
        set => Collection[index] = value;
    }

    /// <summary>
    /// Adds an item to the collection if it is not already present.
    /// </summary>
    /// <param name="value">The item to add.</param>
    public void Add(T value)
    {
        resultOfAdd = false;

        var containsResult = ContainsN(value);
        if (containsResult.HasValue)
        {
            if (!containsResult.Value)
            {
                Collection.Add(value);
                resultOfAdd = true;
            }
        }
        else
        {
            if (!AllowNull.HasValue)
            {
                Collection.Add(value);
                resultOfAdd = true;
            }
        }

        if (resultOfAdd)
            if (IsComparingByString())
                StringRepresentations.Add(StringValue!);
    }

    /// <summary>
    /// Determines whether the collection contains the specified item.
    /// </summary>
    /// <param name="item">The item to check.</param>
    /// <returns>True if the item exists, false otherwise.</returns>
    public bool Contains(T item)
    {
        return ContainsN(item).GetValueOrDefault();
    }

    /// <summary>
    /// Returns the index of the specified item in the collection.
    /// </summary>
    /// <param name="value">The item to find.</param>
    /// <returns>The zero-based index of the item.</returns>
    public abstract int IndexOf(T value);

    /// <summary>
    /// Inserts an item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which to insert the item.</param>
    /// <param name="item">The item to insert.</param>
    public void Insert(int index, T item)
    {
        Collection.Insert(index, item);
    }

    /// <summary>
    /// Removes the item at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the item to remove.</param>
    public void RemoveAt(int index)
    {
        Collection.RemoveAt(index);
    }

    /// <summary>
    /// Removes all items from the collection.
    /// </summary>
    public void Clear()
    {
        Collection.Clear();
    }

    /// <summary>
    /// Copies the items of the collection to an array, starting at a particular index.
    /// </summary>
    /// <param name="array">The destination array.</param>
    /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        Collection.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Removes the first occurrence of a specific item from the collection.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    /// <returns>True if the item was successfully removed, false otherwise.</returns>
    public bool Remove(T item)
    {
        return Collection.Remove(item);
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator for the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    /// <summary>
    /// Determines whether the collection compares items by their string representation.
    /// </summary>
    /// <returns>True if comparing by string, false otherwise.</returns>
    protected abstract bool IsComparingByString();

    /// <summary>
    /// Determines whether the collection contains the specified item.
    /// </summary>
    /// <param name="value">The item to check.</param>
    /// <returns>True if the item exists, false if not, null if the item is null and nulls are allowed.</returns>
    public abstract bool? ContainsN(T value);

    /// <summary>
    /// Adds an item to the collection and returns its index.
    /// </summary>
    /// <param name="value">The item to add.</param>
    /// <returns>The index of the item in the collection.</returns>
    public abstract int AddWithIndex(T value);

    /// <summary>
    /// Adds multiple items to the collection, skipping duplicates.
    /// </summary>
    /// <param name="list">The list of items to add.</param>
    /// <returns>A list of items that were not added because they were duplicates.</returns>
    public List<T> AddRange(IList<T> list)
    {
        wasNotAdded.Clear();
        foreach (var item in list)
        {
            Add(item);
            if (!resultOfAdd) wasNotAdded.Add(item);
        }

        return wasNotAdded;
    }
}