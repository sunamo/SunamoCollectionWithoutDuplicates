namespace SunamoCollectionWithoutDuplicates;

public abstract class CollectionWithoutDuplicatesBase<T> //: IDumpAsString
{
    public static bool BreakOnConstruction = false;
    private bool? _allowNull = false;
    public List<T> Collection { get; set; }
    private readonly int count = 10000;
    public List<string> StringRepresentations { get; set; }
    protected string StringValue = null;
    private readonly List<T> wasNotAdded = new();

    public CollectionWithoutDuplicatesBase()
    {
        if (BreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
    }

    public CollectionWithoutDuplicatesBase(int count)
    {
        this.count = count;
        Collection = new List<T>(count);
    }

    public CollectionWithoutDuplicatesBase(IList<T> list)
    {
        Collection = new List<T>(list.ToList());
    }

    /// <summary>
    ///     true = compareWithString
    ///     false = !compareWithString
    ///     null = allow null (can't compareWithString)
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
                StringRepresentations.Add(StringValue);
        return result;
    }

    protected abstract bool IsComparingByString();
    public abstract bool? Contains(T value);
    public abstract int AddWithIndex(T value);
    public abstract int IndexOf(T value);

    /// <summary>
    ///     If I want without checkink, use c.AddRange
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="withoutChecking"></param>
    public List<T> AddRange(IList<T> list)
    {
        wasNotAdded.Clear();
        foreach (var item in list)
            if (!Add(item))
                wasNotAdded.Add(item);
        return wasNotAdded;
    }

    public string DumpAsString(string operation, /*DumpAsStringHeaderArgs*/ object dumpAsStringHeaderArgs)
    {
        throw new Exception("Nemůže tu být protože DumpListAsStringOneLine jsem přesouval do sunamo a tam už zůstane");
        //return c.DumpAsString(operation, a);
    }
}