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
        public static bool IsWaitForSelectLocation;
        public static SingleRowInfo SelectLocation;

        public static bool IsPlayer1;
        public static bool IsPlayer1Pass;
        public static bool IsPlayer2Pass;
        public static bool IsDiscard;
        public static bool IsCardEffectCompleted;
        /// <summary>
        /// 当前操作者是否pass
        /// </summary>
        public static bool IsCurrectPass => IsPlayer1? IsPlayer1Pass:IsPlayer2Pass;
        /// <summary>
        /// 是否双方皆pass
        /// </summary>
        public static bool IsBoothPass => IsPlayer1Pass&&IsPlayer2Pass;
    }
}
