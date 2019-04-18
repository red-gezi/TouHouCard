
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class Extern
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        enumerable.ToList().ForEach(action);
    }
    public static void Catch(this Task a)
    {
        try
        {
            a.Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine("发现异常");
            Console.WriteLine(Regex.Match(e.ToString(), @"发生一个或多个错误。.*")); //throw e;
        }
    }
}

