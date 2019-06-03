using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class PassCommand : MonoBehaviour
    {
        static GameObject MyPass => Info.UiInfo.Instance.MyPass;
        static GameObject OpPass => Info.UiInfo.Instance.OpPass;
        public static void SetCurrentPass()
        {
            if (Info.GlobalBattleInfo.IsPlayer1 ^ Info.GlobalBattleInfo.IsMyTurn)
            {
                print("玩家1pass");
                Info.GlobalBattleInfo.IsPlayer2Pass = true;
            }
            else
            {
                Info.GlobalBattleInfo.IsPlayer1Pass = true;
                print("玩家2pass");
            }
        }
        public static void ReSetPassState()
        {
            if (Info.GlobalBattleInfo.IsPlayer1 ^ Info.GlobalBattleInfo.IsMyTurn)
            {
                MyPass.SetActive(false);
                OpPass.SetActive(false);
            }
        }
    }
}

