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
        //网络同步信息
        public static int TargetCardID;
        public static Card TargetCard;
        public static Card CreatedCard;
        public static List<int> TargetCardIDList;
        public static List<Card> TargetCardList;
        public static bool IsSelectCardOver;
        public static bool IsCardBoardShow;
        public static bool IsCardBoardHide;
        public static bool CardBoardReload;

        public static Card SingleSelectCardOnBoard=>TargetCardList[SelectBoardCardIds[0]];


        //操作标志位
        public static bool IsCreatCard;
        public static bool IsCreatBoardCardActual;
        public static bool IsCreatBoardCardVitual;
        public static bool IsDestoryCard;
        public static bool IsDestoryBoardCard;
        public static bool IsDiscard;
        public static bool IsCardEffectCompleted;
        public static GameEnum.CardBoardMode CardBoardMode;
        public static bool IsNotifyShow;
        public static bool IsNotifyHide;


        public static Vector3 DragToPoint;
        public static Card PlayerFocusCard;
        public static Card OpponentFocusCard;
        public static Card PlayerPlayCard;

        public static SingleRowInfo PlayerFocusRegion;
        public static bool IsWaitForSelectRegion;
        public static SingleRowInfo SelectRegion;
        //布置点相关字段
        public static Vector3 FocusPoint;
        public static bool IsWaitForSelectLocation;
        public static int SelectLocation = -1;
        //版相关字段
        public static bool IsWaitForSelectBoardCard;
        public static List<int> SelectBoardCardIds;
        public static bool IsFinishSelectBoardCard;
        public static int ChangeableCardNum = 0;
        public static bool IsMyTurn = true;
        public static bool IsPVE = true;
        public static bool IsRevertRows => IsMyTurn ^ IsPlayer1;

        public static int CreatCardId;
        
        /// <summary>
        /// 当前玩家是否玩家1
        /// </summary>
        public static bool IsPlayer1 = true;
        
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