using CardSpace;
using Control;
using Info;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class CardCommand : MonoBehaviour
    {
        static int num = 0;
        public static Card CreatCard(int id)
        {
            //print("生成卡片"+id);
            GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
            NewCard.name = num+"";
            num++;
            var CardStandardInfo = CardLibrary.Instance.CardLibraryList[0].CardModelInfos.First(info => info.CardId == id);
            // print(CardStandardInfo);
            // NewCard.AddComponent(CardLibrary.Instance.CardLibraryList[id].GetType());
            NewCard.AddComponent(Type.GetType("Card" + id));
            Card card = NewCard.GetComponent<Card>();
            card.CardId = CardStandardInfo.CardId;
            card.CardPoint = CardStandardInfo.Point;
            card.icon = CardStandardInfo.Icon;
            NewCard.GetComponent<Renderer>().material.SetTexture("_Front", card.icon);
            card.Init();
            return card;
        }
        public static async Task<Card> CreatCardAsync(int id)
        {
            CardInstanceControl.CreatID = id;
            CardInstanceControl.ShouldCreatCard = true;
            await Task.Run(() => { while (CardInstanceControl.CreatCard == null) { } });
            Card NewCard = CardInstanceControl.CreatCard;
            CardInstanceControl.CreatCard = null;
            //print("异步生成卡牌");
            return NewCard;
        }
        public static async Task DrawCard(bool IsPlayerDraw = true)
        {
            SoundControl.Play();
            //Card TargetCard = RowsInfo.GetRegionCardList(RegionName_Other.My_Deck)[0];
            Card TargetCard = IsPlayerDraw ? RowsInfo.GetMyCardList(RegionTypes.Deck)[0] : RowsInfo.GetOpCardList(RegionTypes.Deck)[0];
            //print(IsPlayerDraw);
            //print("是否我的回合" + GlobalBattleInfo.IsMyTurn);
            //print("是否玩家1" + GlobalBattleInfo.IsPlayer1);
            //print(@"\\\\\\\\\\\\\");

            //TargetCard.IsCanSee = GlobalBattleInfo.IsMyTurn ? IsPlayerDraw : !IsPlayerDraw;
            TargetCard.IsCanSee = IsPlayerDraw;
            if (IsPlayerDraw)
            {
                RowsInfo.GetMyCardList(RegionTypes.Deck).Remove(TargetCard);
                RowsInfo.GetMyCardList(RegionTypes.Hand).Add(TargetCard);
            }
            else
            {
                RowsInfo.GetOpCardList(RegionTypes.Deck).Remove(TargetCard);
                RowsInfo.GetOpCardList(RegionTypes.Hand).Add(TargetCard);
            }
            await Task.Delay(50);
        }
        public static async Task PlayCard()
        {
            SoundControl.Play();
            GameCommand.PlayCardLimit(true);
            Card TargetCard = GlobalBattleInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetMyCardList(RegionTypes.Hand).Remove(TargetCard);
            RowsInfo.GetMyCardList(RegionTypes.Uesd).Add(TargetCard);
            GlobalBattleInfo.PlayerPlayCard = null;
            TargetCard.Trigger<TriggerType.Deploy>();
        }
        public static async Task DisCard(Card card = null)
        {
            Card TargetCard = card == null ? GlobalBattleInfo.PlayerPlayCard : card;
            TargetCard.IsPrePrepareToPlay = false;
            TargetCard.Row.Remove(TargetCard);
            RowsInfo.GetMyCardList(RegionTypes.Grave).Add(TargetCard);
            TargetCard.Trigger<TriggerType.Discard>();
            //await CardEffectStackControl.TriggerEffect<TriggerType.Discard>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task Deploy()
        {
            //Card card = RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard[0];
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Remove(card);
            Card card = RowsInfo.GetMyCardList(RegionTypes.Uesd)[0];
            RowsInfo.GetMyCardList(RegionTypes.Uesd).Remove(card);
            //Card card = GlobalBattleInfo.MyUse[0];
            //GlobalBattleInfo.MyUse.Remove(card);
            GlobalBattleInfo.SelectRegion.ThisRowCard.Insert(GlobalBattleInfo.SelectLocation, card);
            GlobalBattleInfo.SelectRegion = null;
            GlobalBattleInfo.SelectLocation = -1;
            //部署特效
            //print("duang");
            await Task.Delay(2000);
        }
    }
}