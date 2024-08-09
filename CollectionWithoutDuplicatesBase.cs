namespace SunamoCollectionWithoutDuplicates;

public abstract class CollectionWithoutDuplicatesBase<T> //: IDumpAsString
{
    public static bool br = false;
    private bool? _allowNull = false;
    public List<T> c;
    private readonly int count = 10000;
    public List<string> sr;
    protected string ts = null;
    private readonly List<T> wasNotAdded = new();

    public CollectionWithoutDuplicatesBase()
    {
        if (br) Debugger.Break();
        c = new List<T>();
    }

    public CollectionWithoutDuplicatesBase(int count)
    {
        this.count = count;
        c = new List<T>(count);
    }

    public CollectionWithoutDuplicatesBase(IList<T> l)
    {
        c = new List<T>(l.ToList());
    }

    /// <summary>
    ///     true = compareWithString
    ///     false = !compareWithString
    ///     null = allow null (can't compareWithString)
    /// </summary>
    public bool? allowNull
    {
        get => _allowNull;
        set
        {
            _allowNull = value;
            if (value.HasValue && value.Value) sr = new List<string>(count);
        }
    }

    public bool Add(T t2)
    {
        var result = false;
        var con = Contains(t2);
        if (con.HasValue)
        {
            if (!con.Value)
            {
                c.Add(t2);
                result = true;
            }
        }
        else
        {
            if (!allowNull.HasValue)
            {
                c.Add(t2);
                result = true;
            }
        }

        if (result)
            if (IsComparingByString())
                sr.Add(ts);
        return result;
    }

    protected abstract bool IsComparingByString();
    public abstract bool? Contains(T t2);
    public abstract int AddWithIndex(T t2);
    public abstract int IndexOf(T path);

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