using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class UiCommand : MonoBehaviour
    {
        public static void SetCardBoardShow() => Info.GlobalBattleInfo.IsCardBoardShow = true;
        public static void SetCardBoardHide() => Info.GlobalBattleInfo.IsCardBoardShow = false;
        public static void SetNoticeBoardTitle(string Title) => Info.UiInfo.NoticeBoardTitle = Title;
        public static void NoticeBoardShow() => Info.GlobalBattleInfo.IsNotifyShow = true;
        public static void NoticeBoardHide() => Info.GlobalBattleInfo.IsNotifyHide = true;
        public static void SetCardBoardMode(Info.UiInfo.CardBoardMode CardBoardMode) => Info.GlobalBattleInfo.CardBoardMode = CardBoardMode;
    }
}

