using Command;
using Info;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTrigger : MonoBehaviour
{
    static bool IsCreatCard;
   
    void Update()
    {
        Creat();
    }

    private static void Creat()
    {
        if (IsCreatCard)
        {
            CardDeck Deck = PlayInfo.Instance.Deck;
            for (int i = 0; i < Deck.CardID.Count; i++)
            {
                //print("生成一张牌");
                Card NewCard = CardCommand.CreatCard(Deck.CardID[i]);
                RowsInfo.GetRegionCardList(RegionName_Other.My_Deck).Add(NewCard);
            }
            IsCreatCard = false;
        }
    }

    public static void StartCreat()
    {
        IsCreatCard = true;
    }
}
