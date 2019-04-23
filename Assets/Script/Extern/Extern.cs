
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
    public static void Catch(this Task a)
    {
        try
        {
            //File.Create("data.txt");
            a.Wait();
        }
        catch (Exception e)
        {
            //throw e;
            //Console.WriteLine(e);
            //string Text = File.ReadAllText("data.txt");
            //File.WriteAllText("data.txt", Text + e.ToString());
            //UnityEngine.Debug.Log("发现异常");
            //UnityEngine.Debug.Log(e);
            // Console.WriteLine(Regex.Match(e.ToString(), @"发生一个或多个错误。.*")); //throw e;
        }
    }
}

