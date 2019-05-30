using CardSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoardCommand
{
    public static void LoadCardList(List<int> CardsIds)
    {
        Debug.Log("执行虚牌组载入");
        Info.GlobalBattleInfo.TargetCardIDList = CardsIds;
        Info.GlobalBattleInfo.IsCreatBoardCardVitual = true;
    }
    public static void LoadCardList(List<Card> CardsIds)
    {
        Debug.Log("执行实牌组载入");
        Info.GlobalBattleInfo.TargetCardList = CardsIds;
        Info.GlobalBattleInfo.IsCreatBoardCardActual = true;

    }
    public void Replace(int num, Card card)
    {

    }
}
