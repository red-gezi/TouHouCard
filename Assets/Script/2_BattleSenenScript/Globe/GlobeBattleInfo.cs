using CardSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Info
{
    /// <summary>
    /// 全局对战信息
    /// </summary>
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
        public static bool IsPlayer1 = true;
        public static bool IsDiscard;
        public static bool IsCardEffectCompleted;
        public static (int P1Score, int P2Score) PlayerScore;
        public static (int MyScore, int OpScore) ShowScore => IsPlayer1?(PlayerScore.P1Score, PlayerScore.P2Score): (PlayerScore.P2Score, PlayerScore.P1Score);
        public static bool IsPlayer1Pass;
        public static bool IsPlayer2Pass;
        
        /// <summary>
        /// 当前操作者是否pass
        /// </summary>
        public static bool IsCurrectPass => IsPlayer1 ? IsPlayer1Pass : IsPlayer2Pass;
        /// <summary>
        /// 是否双方皆pass
        /// </summary>
        public static bool IsBoothPass => IsPlayer1Pass && IsPlayer2Pass;
    };
}