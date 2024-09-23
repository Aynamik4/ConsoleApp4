namespace MySystem.MyCollections;

//LINQ
//	1. Delegates
//	2. Generics
//	3. Extension Methods
//	4. Interfaces

using System.Collections;

public class MyList<T> : IEnumerable<T>
{
    T[] values = new T[3];

    public int Count { get; private set; } = 0;

    public void Add(T t)
    {
        if (Count == values.Length)
        {
            T[] temp = new T[values.Length * 2];

            for (int i = 0; i < values.Length; i++)
                temp[i] = values[i];

            values = temp;
        }

        values[Count] = t;
        Count++;
    }

    public void Sort(Func<T, T, int> compare)
    {
        for (int i = 0; i < Count - 1; i++)
        {
            int lowValue = i;

            for (int j = i + 1; j < Count; j++)
            {
                if (compare(values[j], values[lowValue]) == -1)
                    lowValue = j;
            }

            if (lowValue != i)
            {
                T temp = values[i];
                values[i] = values[lowValue];
                values[lowValue] = temp;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return values[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return values[i];
        }
    }
}
