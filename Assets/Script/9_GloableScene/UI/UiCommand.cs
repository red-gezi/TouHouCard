using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class Uicommand : MonoBehaviour
    {
        public static void SetCardBoardShow() => Info.GlobalBattleInfo.IsCardBoardShow = true;
        public static void SetCardBoardHide() => Info.GlobalBattleInfo.IsCardBoardShow = false;
        public static void SetCardBoardMode(Info.UiInfo.CardBoardMode CardBoardMode) => Info.GlobalBattleInfo.CardBoardMode = CardBoardMode;
    }
}

