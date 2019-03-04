using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance;
    public static Dialogue Instance1
    {
        get
        {
            return Instance1 == null ? new Dialogue() : Instance1;
        }
    }

    Chara lm = Chara.灵梦;
    Chara zm = Chara.早苗;
    private void Awake()
    {
        Instance = this;
    }
    [Dial(1, 1)]
    public void Dia_1_1()
    {
        say("你好啊早苗", lm, false);
        voice(1);
        say("你好啊,灵梦", zm);
    }
    [Dial(1, 2)]
    public void Dia_1_2()
    {
        say("需要我教你规则吗", zm, false);
        voice(2);
        say("好啊", lm);
    }

    private void voice(int v)
    {
        print($"n播放音乐{v}");
    }
    private void say(string message, Chara chara, bool IsLeft = true)
    {
        print($"{message}                 角色为{chara}，立绘位置在{(IsLeft ? "左边" : "右边")}");
    }
}
enum Chara
{
    灵梦,
    早苗

}
sealed class Dial : Attribute
{
    public int step;
    public int rank;

    public Dial(int step, int rank)
    {
        this.step = step;
        this.rank = rank;
    }
}
