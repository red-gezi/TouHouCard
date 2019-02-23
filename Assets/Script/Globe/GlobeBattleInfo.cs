using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Info
{
    public class GlobeBattleInfo
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
        /// <summary>
        /// 当前玩家是否玩家1
        /// </summary>
        public static bool IsPlayer1 = true;
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
        public static SingleRowInfo MyDeck => !(IsMyTurn ^ IsPlayer1) ? RowsInfo.GetRegionCardList(RegionName_Other.My_Deck) : RowsInfo.GetRegionCardList(RegionName_Other.Op_Deck);
        public static SingleRowInfo OpDeck => IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Other.My_Deck) : RowsInfo.GetRegionCardList(RegionName_Other.Op_Deck);
        public static SingleRowInfo MyHand => !IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Other.My_Hand) : RowsInfo.GetRegionCardList(RegionName_Other.Op_Hand);
        public static SingleRowInfo OpHand => IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Other.My_Hand) : RowsInfo.GetRegionCardList(RegionName_Other.Op_Hand);
        public static SingleRowInfo MyUse => !IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd) : RowsInfo.GetRegionCardList(RegionName_Other.Op_Uesd);
        public static SingleRowInfo MyWater => !IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Battle.My_Water) : RowsInfo.GetRegionCardList(RegionName_Battle.Op_Water);
        public static SingleRowInfo OpWater => IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Battle.My_Water) : RowsInfo.GetRegionCardList(RegionName_Battle.Op_Water);
        public static SingleRowInfo MyWind => !IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Battle.My_Wind) : RowsInfo.GetRegionCardList(RegionName_Battle.Op_Wind);
        public static SingleRowInfo OpWind => IsMyTurn ^ IsPlayer1 ? RowsInfo.GetRegionCardList(RegionName_Battle.My_Wind) : RowsInfo.GetRegionCardList(RegionName_Battle.Op_Wind);

    }
}
