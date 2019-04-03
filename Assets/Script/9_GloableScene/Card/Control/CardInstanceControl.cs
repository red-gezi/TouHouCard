using CardSpace;
using Command;
using Info;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static NetInfoModel;

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
                CreatCard = CardCommand.CreatCard(CreatID);
                CreatID = -1;
                IsCreatCard = false;
            }
        }
        private static void Creat()
        {
            if (IsCreatCard)
            {
                CardDeck Deck = AllPlayerInfo.MyInfo.UseDeck;
                for (int i = 0; i < Deck.CardIds .Count; i++)
                {
                    Card NewCard = CardCommand.CreatCard(Deck.CardIds[i]);
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

