using Command;
using Info;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Control
{
    public class CardInstanceControl : MonoBehaviour
    {
        public static bool IsCreatCard;
        public static Card CreatCard;
        public static int CreatID;

        void Update()
        {
            Creatcard();
            //Creat();
        }
        public static async Task<Card> CardCreatAsync(int ID)
        {
            IsCreatCard = true;
            CreatID = ID;
            await Task.Run(() =>
             {
                 while (CreatCard == null)
                 {

                 }
             });
            Card NewCard = CreatCard;
            NewCard.transform.parent = GameObject.Find("Card").transform;
            CreatCard = null;
            return NewCard;
        }
        private static void Creatcard()
        {
            if (IsCreatCard)
            {
                //print("生成一张牌");
                CreatCard = CardCommand.CreatCard(CreatID);
                CreatID = -1;
                IsCreatCard = false;
            }
        }
        private static void Creat()
        {
            if (IsCreatCard)
            {
                CardDeck Deck = PlayInfo.Instance.MyDeck;
                for (int i = 0; i < Deck.CardID.Count; i++)
                {
                    //print("生成一张牌");
                    Card NewCard = CardCommand.CreatCard(Deck.CardID[i]);
                    RowsInfo.GetRegionCardList(RegionName_Other.My_Deck).ThisRowCard.Add(NewCard);
                }
                IsCreatCard = false;
            }
        }

        public static void StartCreat()
        {
            IsCreatCard = true;
        }
    }
}

