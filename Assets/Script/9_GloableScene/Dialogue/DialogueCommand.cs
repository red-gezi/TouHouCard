using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueCommand : MonoBehaviour
{

    void Start()
    {
        DialogueCommand.play(1, 1);
        DialogueCommand.play(1, 2);
    }
    private static void  play(int v1, int v2)
    {
        foreach (var methond in typeof(Dialogue).GetMethods())
        {
            foreach (Dial info in methond.GetCustomAttributes(typeof(Dial), false))
            {
                if (info.step == v1 && info.rank == v2)
                {
                    methond.Invoke(Dialogue.Instance, new object[] { });
                }
            }
        }
    }
}
