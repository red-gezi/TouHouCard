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
   
    //public class Deck
    //{
    //    public List<int> ids;
    //    public Deck(List<int> ids)
    //    {
    //        this.ids = ids;
    //    }
    //}
    public class GeneralCommand
    {
        public object[] Datas;
        public GeneralCommand(params object[] Datas)
        {
            this.Datas = Datas;
        }
    }
    //public class InfoResult
    //{
    //    public List<Deck> Decks = new List<Deck>();
    //}

    //public class UserInfo
    //{
    //    public string Name;
    //    public string Password;
    //    public UserInfo(string name, string password)
    //    {
    //        Name = name;
    //        Password = password;
    //    }
    //}
    //public class RegisterResult
    //{
    //    public int ResultID;
    //    public RegisterResult(int resultID)
    //    {
    //        ResultID = resultID;
    //    }
    //}
    //public class LoginResult
    //{
    //    public int ResultID;
    //    public InfoResult PlayerInfo;
    //    public LoginResult(int resultID, InfoResult playerInfo)
    //    {
    //        ResultID = resultID;
    //        PlayerInfo = playerInfo;
    //    }
    //}
    public class GeneralCommand<T>
    {
        public T[] Datas;
        public GeneralCommand(params T[] Datas)
        {
            this.Datas = Datas;
        }
    }

}
