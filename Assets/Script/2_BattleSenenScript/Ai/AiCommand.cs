using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class AiCommand : MonoBehaviour
    {
        public static async Task TempOperationAsync()
        {
            await CardCommand.DisCard(Info.GlobalBattleInfo.MyHand[0]);
        }
    }
}

