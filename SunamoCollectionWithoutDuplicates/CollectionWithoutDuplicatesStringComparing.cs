// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionWithoutDuplicates;

public class CollectionWithoutDuplicatesStringComparing<T> : CollectionWithoutDuplicatesBase<T>
{
    public CollectionWithoutDuplicatesStringComparing()
    {
    }

    public CollectionWithoutDuplicatesStringComparing(int count) : base(count)
    {
    }

    public CollectionWithoutDuplicatesStringComparing(IList<T> list) : base(list)
    {
    }

    public override int AddWithIndex(T value)
    {
        if (Contains(value).GetValueOrDefault())
        {
            return StringRepresentations.IndexOf(value.ToString());
        }

        Add(value);
        return Collection.Count - 1;
    }

    public override bool? Contains(T value)
    {
        StringValue = value.ToString();
        return StringRepresentations.Contains(StringValue);
    }

    public override int IndexOf(T value)
    {
        return StringRepresentations.IndexOf(value.ToString());
    }

    protected override bool IsComparingByString()
    {
        return true;
    }
}