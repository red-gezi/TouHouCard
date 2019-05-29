using CardSpace;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardBoardControl : MonoBehaviour
{
    public static CardBoardControl Instance;
    public static bool IsCardBoardShow;
    bool LastIsCardBoardShow;
    public GameObject CardBoard;
    public Transform Constant;
    public GameObject Card;
    public int num;
    static List<int> cardIds => Info.AllPlayerInfo.Player1Info.UseDeck.CardIds;

    public List<GameObject> ShowCardLIst = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        // var CInfo = new NetInfoModel.PlayerInfo("gezi", "yaya", new List<CardDeck> { new CardDeck("gezi", 0, new List<int> { 1000, 1001, 1002, 1001, 1000, 1002, 1000, 1001, 1000, 1001 }) });
        //LoadCardList(CInfo.UseDeck.CardIds);
        //LoadCardList(new List<int> { 1001, 1002 });
    }
    public void LoadCardList(List<int> CardsIds)
    {
        ShowCardLIst.ForEach(Destroy);
        for (int i = 0; i < CardsIds.Count; i++)
        {

            var CardStandardInfo = CardLibrary.GetCardStandardInfo(CardsIds[i]);
            GameObject NewCard = Instantiate(Card);
            NewCard.GetComponent<BoardCardInfo>().Rank = i;
            NewCard.transform.SetParent(Constant);
            Texture2D texture = CardStandardInfo.Icon;
            NewCard.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            ShowCardLIst.Add(NewCard);
        }
        Constant.GetComponent<RectTransform>().sizeDelta = new Vector2(CardsIds.Count * 325 + 200, 800);
    }
    public void LoadCardList(List<Card> CardsIds)
    {
        ShowCardLIst.ForEach(Destroy);
        for (int i = 0; i < CardsIds.Count; i++)
        {
            var CardStandardInfo = CardLibrary.GetCardStandardInfo(CardsIds[i].CardId );
            GameObject NewCard = Instantiate(Card);
            NewCard.GetComponent<BoardCardInfo>().Rank = i;
            NewCard.transform.SetParent(Constant);
            Texture2D texture = CardStandardInfo.Icon;
            NewCard.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            ShowCardLIst.Add(NewCard);
        }
        Constant.GetComponent<RectTransform>().sizeDelta = new Vector2(CardsIds.Count * 325 + 200, 800);
    }
    public void Replace(int num, Card card)
    {
        for (int i = 0; i < num; i++)
        {
            ShowCardLIst.ForEach(Destroy);
        }
        Constant.GetComponent<RectTransform>().sizeDelta = new Vector2(num * 325 + 200, 800);
    }
    // Update is called once per frame
    void Update()
    {
        if (LastIsCardBoardShow != IsCardBoardShow)
        {
            CardBoard.SetActive(IsCardBoardShow);
            LastIsCardBoardShow = IsCardBoardShow;
        }
    }
    public static void SetCardBoardShow(bool IsActive)
    {
        IsCardBoardShow = IsActive;
    }
}
