using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueCommand : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        DialogueCommand.play(1, 1);
        DialogueCommand.play(1, 2);
    }

    private static void  play(int v1, int v2)
    {
        //typeof(Dialogue).GetMethods().ToList().ForEach(step=>step.GetCustomAttributesData(Dial).)
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

    // Update is called once per frame
    void Update()
    {

    }
}
