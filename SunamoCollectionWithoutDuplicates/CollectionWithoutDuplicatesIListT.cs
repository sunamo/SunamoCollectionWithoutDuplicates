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

    public override int IndexOf(T value) => Collection.IndexOf(value);

    protected override bool IsComparingByString() => false;
}
