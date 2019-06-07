﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class UiCommand : MonoBehaviour
    {
        static GameObject MyPass => Info.UiInfo.Instance.MyPass;
        static GameObject OpPass => Info.UiInfo.Instance.OpPass;
        public static void SetCardBoardShow() => Info.GlobalBattleInfo.IsCardBoardShow = true;
        public static void SetCardBoardHide() => Info.GlobalBattleInfo.IsCardBoardHide = true;
        public static void CardBoardReload() => Info.GlobalBattleInfo.CardBoardReload = true;
        public static Sprite GetBoardCardImage(int Id)
        {
            if (!Info.UiInfo.CardImage.ContainsKey(Id))
            {
                var CardStandardInfo = CardLibrary.GetCardStandardInfo(Id);
                Texture2D texture = CardStandardInfo.Icon;
                Info.UiInfo.CardImage.Add(Id, Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero));
            }
            return Info.UiInfo.CardImage[Id];
        }
        public static void SetCardBoardTitle(string Title) => Info.UiInfo.CardBoardTitle = Title;
        public static void SetNoticeBoardTitle(string Title) => Info.UiInfo.NoticeBoardTitle = Title;

        public static void NoticeBoardShow() => Info.GlobalBattleInfo.IsNotifyShow = true;
        public static void NoticeBoardHide() => Info.GlobalBattleInfo.IsNotifyHide = true;
        public static void SetCardBoardMode(GameEnum.CardBoardMode CardBoardMode) => Info.GlobalBattleInfo.CardBoardMode = CardBoardMode;
        public static void SetCurrentPass()
        {
            if (Info.GlobalBattleInfo.IsPlayer1 ^ Info.GlobalBattleInfo.IsMyTurn)
            {
                Info.GlobalBattleInfo.IsPlayer2Pass = true;
            }
            else
            {
                Info.GlobalBattleInfo.IsPlayer1Pass = true;
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

