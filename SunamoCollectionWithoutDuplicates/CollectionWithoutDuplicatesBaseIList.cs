namespace SunamoCollectionWithoutDuplicates;

/// <summary>
/// Represents the collection without duplicates base i list t type.
/// </summary>
public abstract class CollectionWithoutDuplicatesBaseIList<T> : IDumpAsString, IList<T>
{
    /// <summary>
    /// Gets or sets the should break on construction.
    /// </summary>
    public static bool ShouldBreakOnConstruction { get; set; }

    private bool? allowNull = false;

    /// <summary>
    /// Gets or sets the collection.
    /// </summary>
    public List<T> Collection { get; set; }

    private readonly int initialCapacity = 10000;

    private bool wasAdded;

    /// <summary>
    /// Gets or sets the result of bool n.
    /// </summary>
    public bool? ResultOfBoolN { get; set; }

    /// <summary>
    /// Gets or sets the string representations.
    /// </summary>
    public List<string> StringRepresentations { get; set; }

    /// <summary>
    /// Gets or sets the string value.
    /// </summary>
    protected string? StringValue { get; set; }

    private readonly List<T> duplicateItems = new();

    /// <summary>
    /// Initializes a new instance of the collection without duplicates base i list class.
    /// </summary>
    public CollectionWithoutDuplicatesBaseIList()
    {
        if (ShouldBreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Collection without duplicates base i list.
    /// </summary>
    /// <returns>The collection without duplicates base i list result.</returns>
    public CollectionWithoutDuplicatesBaseIList(int initialCapacity)
    {
        this.initialCapacity = initialCapacity;
        Collection = new List<T>(initialCapacity);
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates base i list class.
    /// </summary>
    public CollectionWithoutDuplicatesBaseIList(IList<T> list)
    {
        Collection = new List<T>(list.ToList());
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// The allow null.
    /// </summary>
    public bool? AllowNull
    {
        get => allowNull;
        set
        {
            allowNull = value;
            if (value.HasValue && value.Value) StringRepresentations = new List<string>(initialCapacity);
        }
    }

    /// <summary>
    /// Dump as string.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list.ToList()">The list to list.</param>
    /// <returns>The dump as string result.</returns>
    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
    }

    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => Collection.Count;

    /// <summary>
    /// Gets the is read only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// The this int.
    /// </summary>
    public T this[int index]
    {
        get => Collection[index];
        set => Collection[index] = value;
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="operation">The operation.</param>
    /// <param name="dumpAsStringHeaderArgs">The dump as string header args.</param>
    /// <returns>The add result.</returns>
    public void Add(T value)
    {
        wasAdded = false;

        var containsResult = ContainsN(value);
        if (containsResult.HasValue)
        {
            if (!containsResult.Value)
            {
                Collection.Add(value);
                wasAdded = true;
            }
        }
        else
        {
            if (!AllowNull.HasValue)
            {
                Collection.Add(value);
                wasAdded = true;
            }
        }

        if (wasAdded)
            if (IsComparingByString())
                StringRepresentations.Add(StringValue!);
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="value">The value.</param>
    public bool Contains(T value)
    {
        return ContainsN(value).GetValueOrDefault();
    }

    /// <summary>
    /// Initializes a new instance of the index of class.
    /// </summary>
    /// <param name="containsResult.HasValue">The contains result has value.</param>
    public abstract int IndexOf(T value);

    /// <summary>
    /// Initializes a new instance of the insert class.
    /// </summary>
    /// <param name="!containsResult.Value">The contains result value.</param>
    public void Insert(int index, T value)
    {
        Collection.Insert(index, value);
    }

    /// <summary>
    /// Remove at.
    /// </summary>
    /// <param name="!AllowNull.HasValue">The allow null has value.</param>
    /// <returns>The remove at result.</returns>
    public void RemoveAt(int index)
    {
        Collection.RemoveAt(index);
    }

    /// <summary>
    /// Initializes a new instance of the clear class.
    /// </summary>
    /// <param name="value">The value.</param>
    public void Clear()
    {
        Collection.Clear();
    }

    /// <summary>
    /// Initializes a new instance of the copy to class.
    /// </summary>
    /// <param name="wasAdded">The was added.</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
        Collection.CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The remove result.</returns>
    public bool Remove(T value)
    {
        return Collection.Remove(value);
    }

    /// <summary>
    /// Get enumerator.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The get enumerator result.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    /// <returns>The is comparing by string result.</returns>
    protected abstract bool IsComparingByString();

    /// <summary>
    /// Contains n.
    /// </summary>
    public abstract bool? ContainsN(T value);

    /// <summary>
    /// Initializes a new instance of the add with index class.
    /// </summary>
    public abstract int AddWithIndex(T value);

    /// <summary>
    /// Add range.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <param name="arrayIndex">The array index.</param>
    public List<T> AddRange(IList<T> list)
    {
        duplicateItems.Clear();
        foreach (var item in list)
        {
            Add(item);
            if (!wasAdded) duplicateItems.Add(item);
        }

        return duplicateItems;
    }
}
