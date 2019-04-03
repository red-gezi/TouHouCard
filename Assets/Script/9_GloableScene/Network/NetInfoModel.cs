using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetInfoModel : MonoBehaviour
{
    public class PlayerInfo
    {
        public string _id;
        public string Name;
        public string Password;
        public int Level;
        public int Rank;
        public int Faith;
        public int Recharge;
        public int UseDeckNum;
        public List<CardDeck> Deck;
        public CardDeck UseDeck => Deck[UseDeckNum];

        public PlayerInfo(string Name, string Password, List<CardDeck> Deck)
        {
            this.Name = Name;
            this.Deck = Deck;
            this.Password = Password;
            Level = 0;
            Rank = 0;
            Faith = 0;
            Recharge = 0;
            UseDeckNum = 0;
        }

    }
    public class GeneralCommand
    {
        public object[] Datas;
        public GeneralCommand(params object[] Datas)
        {
            this.Datas = Datas;
        }
    }
    public class GeneralCommand<T>
    {
        public T[] Datas;
        public GeneralCommand(params T[] Datas)
        {
            this.Datas = Datas;
        }
    }

}
