﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Info
{
    public class GlobalBattleInfo
    {
        public static Vector3 DragToPoint;
        public static Card PlayerFocusCard;
        public static Card OpponentFocusCard;
        public static Card PlayerPlayCard;

        public static SingleRowInfo PlayerFocusRegion;
        public static bool IsWaitForSelectRegion;
        public static SingleRowInfo SelectRegion;

        public static Vector3 FocusPoint;
        public static bool IsWaitForSelectLocation;
        public static int SelectLocation = -1;

        public static bool IsMyTurn = true;
        public static bool IsPVE = true;
        public static bool IsRevertRows => IsMyTurn ^ IsPlayer1;

        /// <summary>
        /// 当前玩家是否玩家1
        /// </summary>
        public static bool IsPlayer1 = false;
        public static bool IsPlayer1Pass;
        public static bool IsPlayer2Pass;
        public static bool IsDiscard;
        public static bool IsCardEffectCompleted;
        /// <summary>
        /// 当前操作者是否pass
        /// </summary>
        public static bool IsCurrectPass => IsPlayer1 ? IsPlayer1Pass : IsPlayer2Pass;
        /// <summary>
        /// 是否双方皆pass
        /// </summary>
        public static bool IsBoothPass => IsPlayer1Pass && IsPlayer2Pass;
        public static List<Card> MyDeck => !IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Deck) : RowsInfo.GetCardList(RegionType.Op_Deck);
        public static List<Card> OpDeck => IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Deck) : RowsInfo.GetCardList(RegionType.Op_Deck);
        public static List<Card> MyGrave => !IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Grave) : RowsInfo.GetCardList(RegionType.Op_Grave);
        public static List<Card> OpGrave => IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Grave) : RowsInfo.GetCardList(RegionType.Op_Grave);
        public static List<Card> MyHand => !IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Hand) : RowsInfo.GetCardList(RegionType.Op_Hand);
        public static List<Card> OpHand => IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Hand) : RowsInfo.GetCardList(RegionType.Op_Hand);
        public static List<Card> MyUse => !IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Uesd) : RowsInfo.GetCardList(RegionType.Op_Uesd);
        public static List<Card> OpUse => IsRevertRows ? RowsInfo.GetCardList(RegionType.My_Uesd) : RowsInfo.GetCardList(RegionType.Op_Uesd);
        /// <summary>
        /// 属性
        /// </summary>
        public static List<Card> MyWater => !IsMyTurn ^ IsPlayer1 ? RowsInfo.GetCardList(RegionType.My_Water) : RowsInfo.GetCardList(RegionType.Op_Water);
        public static List<Card> OpWater => IsMyTurn ^ IsPlayer1 ? RowsInfo.GetCardList(RegionType.My_Water) : RowsInfo.GetCardList(RegionType.Op_Water);

        public static List<Card> MyWind => !IsMyTurn ^ IsPlayer1 ? RowsInfo.GetCardList(RegionType.My_Wind) : RowsInfo.GetCardList(RegionType.Op_Wind);
        public static List<Card> OpWind => IsMyTurn ^ IsPlayer1 ? RowsInfo.GetCardList(RegionType.My_Wind) : RowsInfo.GetCardList(RegionType.Op_Wind);
        // public static List<SingleRowInfo> AllRow => new List<SingleRowInfo> { MyDeck, OpDeck, MyHand, OpHand, MyUse, MyWater, OpWater, MyWind, OpWind };
    };
}