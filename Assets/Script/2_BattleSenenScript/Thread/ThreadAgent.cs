using CardSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Info
{

    public class ThreadAgent : MonoBehaviour
    {
        static int num;
        static bool num2;
        private void Update()
        {
            //InvokeInMainThread(Info.GlobalBattleInfo.IsCreatCard, CreatCard);
            //InvokeInMainThread(Info.GlobalBattleInfo.IsCreatCard, DestoryCard);
            InvokeInMainThread(ref Info.GlobalBattleInfo.IsCreatBoardCardActual, CreatBoardCardActual);
            InvokeInMainThread(ref Info.GlobalBattleInfo.IsCreatBoardCardVitual, CreatBoardCardVitual);
        }
        private void InvokeInMainThread(ref bool TriggerSign, Action RunFunction)
        {
            if (TriggerSign)
            {
                RunFunction();
                TriggerSign = false;
                print("TriggerSign为" + TriggerSign);
            }
        }
        private static void CreatCard()
        {
            GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
            NewCard.name = num + "";
            num++;
            int id = Info.GlobalBattleInfo.TargetCardID;
            var CardStandardInfo = CardLibrary.GetCardStandardInfo(id);
            NewCard.AddComponent(Type.GetType("Card" + id));
            Card card = NewCard.GetComponent<Card>();
            card.CardId = CardStandardInfo.CardId;
            card.CardPoint = CardStandardInfo.Point;
            card.icon = CardStandardInfo.Icon;
            card.CardProperty = CardStandardInfo.CardProperty;
            card.CardTerritory = CardStandardInfo.CardTerritory;
            card.GetComponent<Renderer>().material.SetTexture("_Front", card.icon);
            card.Init();
            Info.GlobalBattleInfo.CreatedCard = card;
        }
        private static void DestoryCard()
        {
        }
        private static void CreatBoardCardActual()
        {
            print(Info.GlobalBattleInfo.IsCreatBoardCardActual);
            Info.CardBoardInfo.ShowBoardCardLIst.ForEach(Destroy);
            List<Card> Cards = Info.GlobalBattleInfo.TargetCardList;
            print(Cards.Count);

            for (int i = 0; i < Cards.Count; i++)
            {
                var CardStandardInfo = CardLibrary.GetCardStandardInfo(Cards[i].CardId);
                GameObject NewCard = Instantiate(Info.CardBoardInfo.CardModel);
                NewCard.GetComponent<BoardCardInfo>().Rank = i;
                NewCard.transform.SetParent(Info.CardBoardInfo.Constant);
                Texture2D texture = CardStandardInfo.Icon;
                NewCard.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                Info.CardBoardInfo.ShowBoardCardLIst.Add(NewCard);
            }
            Info.CardBoardInfo.Constant.GetComponent<RectTransform>().sizeDelta = new Vector2(Cards.Count * 325 + 200, 800);
        }
        private static void CreatBoardCardVitual()
        {
            Info.CardBoardInfo.ShowBoardCardLIst.ForEach(Destroy);
            List<int> CardIds = Info.GlobalBattleInfo.TargetCardIDList;
            for (int i = 0; i < CardIds.Count; i++)
            {
                var CardStandardInfo = CardLibrary.GetCardStandardInfo(CardIds[i]);
                GameObject NewCard = Instantiate(Info.CardBoardInfo.CardModel);
                NewCard.GetComponent<BoardCardInfo>().Rank = i;
                NewCard.transform.SetParent(Info.CardBoardInfo.Constant);
                Texture2D texture = CardStandardInfo.Icon;
                NewCard.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                Info.CardBoardInfo.ShowBoardCardLIst.Add(NewCard);
            }
            Info.CardBoardInfo.Constant.GetComponent<RectTransform>().sizeDelta = new Vector2(CardIds.Count * 325 + 200, 800);
        }

    }
}
