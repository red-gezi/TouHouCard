
using System;
using System.Collections.Generic;
using System.Linq;

public static class Extern
{
    public static void ForEach<T>(this IEnumerable<T> enumerable,Action<T> action)
    {
        enumerable.ToList().ForEach(action);
    }
}

