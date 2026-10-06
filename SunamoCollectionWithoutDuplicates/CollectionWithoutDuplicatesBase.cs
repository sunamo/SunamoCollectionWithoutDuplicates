namespace SunamoCollectionWithoutDuplicates;

public abstract class CollectionWithoutDuplicatesBase<T>
{
    public static bool ShouldBreakOnConstruction { get; set; }

    private bool? allowNull = false;

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

    public CollectionWithoutDuplicatesBase()
    {
        if (ShouldBreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
        StringRepresentations = new List<string>();
    }

    public CollectionWithoutDuplicatesBase(int initialCapacity)
    {
        this.initialCapacity = initialCapacity;
        Collection = new List<T>(initialCapacity);
        StringRepresentations = new List<string>();
    }

    public CollectionWithoutDuplicatesBase(IList<T> list)
    {
        Collection = new List<T>(list.ToList());
        StringRepresentations = new List<string>();
    }

    public bool? AllowNull
    {
        get => allowNull;
        set
        {
            allowNull = value;
            if (value.HasValue && value.Value) StringRepresentations = new List<string>(initialCapacity);
        }
    }

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

    protected abstract bool IsComparingByString();

    public abstract bool? Contains(T value);

    public abstract int AddWithIndex(T value);

    public abstract int IndexOf(T value);

    public List<T> AddRange(IList<T> list)
    {
        duplicateItems.Clear();
        foreach (var item in list)
            if (!Add(item))
                duplicateItems.Add(item);
        return duplicateItems;
    }

    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
    }
}
