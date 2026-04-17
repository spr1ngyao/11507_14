namespace Task1;

public class Storage<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public List<T> FindAll(Predicate<T> match)
    {
        List<T> result = new List<T>();
        foreach (var item in _items)
        {
            if (match(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public int GetCount(Predicate<T> match)
    {
        int count = 0;
        foreach (var item in _items)
        {
            if (match(item))
            {
                count++;
            }
        }
        return count;
    }
}