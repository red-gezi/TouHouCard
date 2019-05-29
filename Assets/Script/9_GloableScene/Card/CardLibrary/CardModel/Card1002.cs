using CardSpace;
using Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Card1002 : Card
{
    int time = 2;
    [TriggerType.Deploy]
    public Func<Task> Step1 => (async () => { print("test"); await Task.Delay(1000); });
    [TriggerType.Deploy]
    public Func<Task> Step2 => (async () =>
    {
        await StateCommand.WaitForSelectBoardCard(new List<int>() { 1002,1002});
        await StateCommand.WaitForSelectLocation();
        await CardCommand.Deploy();
        await Task.Delay(100);
        await Task.Delay(time);
    });
}
