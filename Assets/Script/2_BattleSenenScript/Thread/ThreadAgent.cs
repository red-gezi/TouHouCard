using CardSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{

    public class ThreadAgent : MonoBehaviour
    {
        static int num;
        static bool num2;
        static bool IsCreatCard { get => Info.GlobalBattleInfo.IsCreatCard; set => Info.GlobalBattleInfo.IsCreatCard = value; }
        static int CreatCardId { get => Info.GlobalBattleInfo.CreatCardId; set => Info.GlobalBattleInfo.CreatCardId = value; }
        static bool IsDestoryCard { get => Info.GlobalBattleInfo.IsDiscard; set => Info.GlobalBattleInfo.IsCreatCard = value; }
        static Card TargeCard => new Card();
        private void Update()
        {
            InvokeInMainThread(IsCreatCard, CreatCard);
            InvokeInMainThread(IsDestoryCard, DestoryCard);
        }

        private void InvokeInMainThread(bool TriggerSign, Action RunFunction)
        {
            if (TriggerSign)
            {
                //Command.CardCommand.
                RunFunction();
                TriggerSign = false;
            }

        }
        private static void CreatCard()
        {

        }
        private static Card CreatCard(int id)
        {
            GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
            NewCard.name = num + "";
            num++;
            var CardStandardInfo = CardLibrary.GetCardStandardInfo(id);
            NewCard.AddComponent(Type.GetType("Card" + id));
            Card card = NewCard.GetComponent<Card>();
            card.CardId = CardStandardInfo.CardId;
            card.CardPoint = CardStandardInfo.Point;
            card.icon = CardStandardInfo.Icon;
            card.CardProperty = CardStandardInfo.CardProperty;
            card.CardTerritory = CardStandardInfo.CardTerritory;
            NewCard.GetComponent<Renderer>().material.SetTexture("_Front", card.icon);
            card.Init();
            return card;
        }
        private static void CreatBoardCard()
        {
            
            ShowCardLIst.ForEach(Destroy);
            for (int i = 0; i < CardsIds.Count; i++)
            {
                var CardStandardInfo = CardLibrary.GetCardStandardInfo(CardsIds[i].CardId);
                GameObject NewCard = Instantiate(Card);
                NewCard.GetComponent<BoardCardInfo>().Rank = i;
                NewCard.transform.SetParent(Constant);
                Texture2D texture = CardStandardInfo.Icon;
                NewCard.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                ShowCardLIst.Add(NewCard);
            }
            Constant.GetComponent<RectTransform>().sizeDelta = new Vector2(CardsIds.Count * 325 + 200, 800);
        }
        private static void DestoryCard()
        {
            System.Console.WriteLine();
        }
    }
}
