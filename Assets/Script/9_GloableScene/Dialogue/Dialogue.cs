using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static DialgueInfo;
using static DialogueCommand;
public class Dialogue : MonoBehaviour
{
    //public static Dialogue Instance;
    public static Dialogue Instance;//=> Instance ?? new Dialogue();
    Chara lmA = Chara.灵梦A;
    Chara lmB = Chara.灵梦B;
    private void Awake()
    {
        Instance = this;
    }
    [Dial(1, 1)]
    public async Task Dia_1_1()
    {
        await say("你好啊,灵梦", lmB, false);
        await say("你好啊", lmA);
        await say("你有钱吗", lmB, false);
        await say("没有呢。。。", lmA,FaceNum:1);
        await say("...我也是", lmB, false, FaceNum:1);
    }
    [Dial(1, 2)]
    public async Task Dia_1_2()
    {
        await say("需要我教你规则吗", lmB, false);
        voice(2);
        await say("好啊", lmA);
    }


}


