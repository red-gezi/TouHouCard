
using CardSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class Extern
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        enumerable.ToList().ForEach(action);
    }
   
}

