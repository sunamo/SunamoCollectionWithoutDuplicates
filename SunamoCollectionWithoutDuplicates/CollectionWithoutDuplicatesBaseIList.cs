namespace SunamoCollectionWithoutDuplicates;

public abstract class CollectionWithoutDuplicatesBaseIList<T> : IDumpAsString, IList<T>
{
    public static bool ShouldBreakOnConstruction { get; set; }

    private bool? allowNull = false;

    public List<T> Collection { get; set; }

    private readonly int initialCapacity = 10000;

    private bool wasAdded;

    public bool? ResultOfBoolN { get; set; }

    public List<string> StringRepresentations { get; set; }

    protected string? StringValue { get; set; }

    private readonly List<T> duplicateItems = new();

    public CollectionWithoutDuplicatesBaseIList()
    {
        if (ShouldBreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
        StringRepresentations = new List<string>();
    }

    public CollectionWithoutDuplicatesBaseIList(int initialCapacity)
    {
        this.initialCapacity = initialCapacity;
        Collection = new List<T>(initialCapacity);
        StringRepresentations = new List<string>();
    }

    public CollectionWithoutDuplicatesBaseIList(IList<T> list)
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

    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
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

    public bool Contains(T value)
    {
        return ContainsN(value).GetValueOrDefault();
    }

    public abstract int IndexOf(T value);

    public void Insert(int index, T value)
    {
        Collection.Insert(index, value);
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

    public bool Remove(T value)
    {
        return Collection.Remove(value);
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
