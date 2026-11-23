namespace SunamoCollectionWithoutDuplicates;

/// <summary>
/// Represents the collection without duplicates base t type.
/// </summary>
public abstract class CollectionWithoutDuplicatesBase<T>
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

    /// <summary>
    /// Gets or sets the string representations of items when comparing by string.
    /// </summary>
    /// <summary>
    /// The string value of the current item being processed.
    /// </summary>
    protected string? StringValue { get; set; }

    private readonly List<T> duplicateItems = new();

    /// <summary>
    /// Initializes a new instance of the collection without duplicates.
    /// </summary>
    public List<string> StringRepresentations { get; set; }

    /// <summary>
    /// Collection without duplicates base.
    /// </summary>
    /// <returns>The collection without duplicates base result.</returns>
    public CollectionWithoutDuplicatesBase()
    {
        if (ShouldBreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Collection without duplicates base.
    /// </summary>
    /// <param name="ShouldBreakOnConstruction">The should break on construction.</param>
    /// <returns>The collection without duplicates base result.</returns>
    public CollectionWithoutDuplicatesBase(int initialCapacity)
    {
        this.initialCapacity = initialCapacity;
        Collection = new List<T>(initialCapacity);
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Collection without duplicates base.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="initialCapacity">The initial capacity.</param>
    /// <returns>The collection without duplicates base result.</returns>
    public CollectionWithoutDuplicatesBase(IList<T> list)
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
    /// Add.
    /// </summary>
    /// <param name="value.Value">The value value.</param>
    /// <returns>The add result.</returns>
    public bool Add(T value)
    {
        var result = false;
        var containsResult = Contains(value);
        if (containsResult.HasValue)
        {
            if (!containsResult.Value)
            {
                Collection.Add(value);
                result = true;
            }
        }
        else
        {
            if (!AllowNull.HasValue)
            {
                Collection.Add(value);
                result = true;
            }
        }

        if (result)
            if (IsComparingByString())
                StringRepresentations.Add(StringValue!);
        return result;
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The is comparing by string result.</returns>
    protected abstract bool IsComparingByString();

    /// <summary>
    /// Initializes a new instance of the contains class.
    /// </summary>
    /// <param name="result">The result.</param>
    public abstract bool? Contains(T value);

    /// <summary>
    /// Initializes a new instance of the add with index class.
    /// </summary>
    /// <param name="IsComparingByString()">The is comparing by string.</param>
    public abstract int AddWithIndex(T value);

    /// <summary>
    /// Index of.
    /// </summary>
    /// <returns>The index of result.</returns>
    public abstract int IndexOf(T value);

    /// <summary>
    /// Add range.
    /// </summary>
    /// <returns>The add range result.</returns>
    public List<T> AddRange(IList<T> list)
    {
        duplicateItems.Clear();
        foreach (var item in list)
            if (!Add(item))
                duplicateItems.Add(item);
        return duplicateItems;
    }

    /// <summary>
    /// Dump as string.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The dump as string result.</returns>
    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
    }
}
