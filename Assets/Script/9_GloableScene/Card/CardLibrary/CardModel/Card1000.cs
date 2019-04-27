using CardSpace;
using Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Card1000 : Card
{
    [TriggerType.Deploy]
    public Func<Task> Step1 => (async () => { print("test"); await Task.Delay(1000); });
    [TriggerType.Deploy]
    public Func<Task> Step2 => (async () =>
    {
        print("µÈ´ýÑ¡ÔñÎ»ÖÃ");
        await GameCommand.WaitForSelectLocation();
        await CardCommand.Deploy();
        await Task.Delay(100);
    });
}
