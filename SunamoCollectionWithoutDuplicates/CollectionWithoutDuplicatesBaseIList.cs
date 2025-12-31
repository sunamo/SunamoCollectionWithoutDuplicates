namespace SunamoCollectionWithoutDuplicates;

public abstract class CollectionWithoutDuplicatesBaseIList<T> : IDumpAsString, IList<T>
{
    public static bool BreakOnConstruction = false;
    private bool? _allowNull = false;
    public List<T> Collection { get; set; }
    private readonly int count = 10000;

    private bool resultOfAdd;

    /// <summary>
    ///     Dříve vracela Contains() bool? ale musí splňoval IList
    /// </summary>
    public bool? ResultOfBoolN { get; set; } = null;

    public List<string> StringRepresentations { get; set; }

    protected string StringValue = null;

    private readonly List<T> wasNotAdded = new();

    public CollectionWithoutDuplicatesBaseIList()
    {
        if (BreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
    }

    public CollectionWithoutDuplicatesBaseIList(int count)
    {
        this.count = count;
        Collection = new List<T>(count);
    }

    public CollectionWithoutDuplicatesBaseIList(IList<T> list)
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

    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Nemůže tu být protože DumpListAsStringOneLine jsem přesouval do sunamo a tam už zůstane");
        //return c.DumpAsString(operation, a);
    }

    public int Count => Collection.Count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get => Collection[index];
        set => Collection[index] = value;
    }

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
                StringRepresentations.Add(StringValue);
    }

    public bool Contains(T item)
    {
        return ContainsN(item).GetValueOrDefault();
    }

    public abstract int IndexOf(T value);

    public void Insert(int index, T item)
    {
        Collection.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        Collection.RemoveAt(index);
    }

    public void Clear()
    {
        Collection.Clear();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Collection.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        return Collection.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Collection.GetEnumerator();
    }

    protected abstract bool IsComparingByString();

    public abstract bool? ContainsN(T value);

    public abstract int AddWithIndex(T value);

    /// <summary>
    ///     If I want without checkink, use c.AddRange
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="withoutChecking"></param>
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