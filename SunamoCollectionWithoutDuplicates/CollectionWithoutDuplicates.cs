namespace SunamoCollectionWithoutDuplicates;

public class CollectionWithoutDuplicates<T> : CollectionWithoutDuplicatesBase<T>
{
    public CollectionWithoutDuplicates()
    {
    }

    public CollectionWithoutDuplicates(int count) : base(count)
    {
    }

    public CollectionWithoutDuplicates(IList<T> list) : base(list)
    {
    }

    public override int AddWithIndex(T value)
    {
        if (IsComparingByString())
        {
            if (Contains(value).GetValueOrDefault())
            {
                // Will checkout below
            }
            else
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

    public override bool? Contains(T value)
    {
        if (IsComparingByString())
        {
            StringValue = value.ToString();
            return StringRepresentations.Contains(StringValue);
        }

        if (!Collection.Contains(value))
        {
            if (EqualityComparer<T>.Default.Equals(value, default)) return null;
            return false;
        }

        return true;
    }

    public override int IndexOf(T value)
    {
        if (IsComparingByString()) return StringRepresentations.IndexOf(value.ToString());
        var index = Collection.IndexOf(value);
        if (index == -1)
        {
            Collection.Add(value);
            return Collection.Count - 1;
        }

        return index;
    }

    protected override bool IsComparingByString()
    {
        return AllowNull.HasValue && AllowNull.Value;
    }
}