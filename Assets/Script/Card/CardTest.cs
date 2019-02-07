using Info;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CardTest : Card
{

    [TriggerType.Deploy]
    public Func<Task> Step1 = (async () => { print("test"); await Task.Delay(1000); });



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsMove = IsAutoMove;
        yaya = GlobeCardInfo.PlayerPlayCard;
    }
}
