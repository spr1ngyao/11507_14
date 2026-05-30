using System;
using System.Collections.Generic;

namespace Events;

public static class EnumerableExtensions
{
    public static void ForEachWithIndex<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        int index = 0;
        foreach (T item in source)
        {
            action(item, index);
            index++;
        }
    }
}