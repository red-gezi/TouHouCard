using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using static DialgueInfo;

public class DialogueCommand : MonoBehaviour
{

    public static void play(int v1, int v2)
    {
        print("yaya");
        foreach (var methond in typeof(Dialogue).GetMethods())
        {
            foreach (Dial info in methond.GetCustomAttributes(typeof(Dial), false))
            {
                print("one");

                if (info.step == v1 && info.rank == v2)
                {
                    methond.Invoke(Dialogue.Instance, new object[] { });
                }
            }
        }
    }
    public static void voice(int v)
    {
        print($"n播放音乐{v}");
    }
    public static async Task say(string message, Chara chara, bool IsLeft = true, int FaceNum = 0)
    {
        print($"{message}                 角色为{chara}，立绘位置在{(IsLeft ? "左边" : "右边")}");
        DialgueInfos.Text.text = chara + ":" + message;
        if (IsLeft)
        {
            DialgueInfos.Left.GetComponent<Live2d>().FaceRank = FaceNum;
            DialgueInfos.Left.gameObject.transform.localScale *= 1.1f;
        }
        else
        {
            DialgueInfos.Right.GetComponent<Live2d>().FaceRank = FaceNum;
            DialgueInfos.Right.gameObject.transform.localScale *= 1.1f;
        }
        await Task.Run(() =>
        {
            while (!DialgueInfos.IsNext)
            {
                Debug.Log("yaya");
            }
        });
        DialgueInfos.IsNext = false;
        if (IsLeft)
        {
            DialgueInfos.Left.gameObject.transform.localScale /= 1.1f;
        }
        else
        {
            DialgueInfos.Right.gameObject.transform.localScale /= 1.1f;
        }
    }
}
