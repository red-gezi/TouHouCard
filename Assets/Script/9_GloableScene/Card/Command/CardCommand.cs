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
        public static Card CreatCard(int id)
        {
            print("生成卡片"+id);
            GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
            var CardStandardInfo = CardLibrary.Instance.CardLibraryList[0].CardModelInfos.First(info=>info.CardId==id);
            print(CardStandardInfo);
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
            print("异步生成卡牌");
            return NewCard;
        }
        public static async Task DrawCard(bool IsPlayerDraw = true)
        {
            SoundControl.Play();
            //Card TargetCard = RowsInfo.GetRegionCardList(RegionName_Other.My_Deck)[0];
            Card TargetCard = IsPlayerDraw ? GlobalBattleInfo.MyDeck[0] : GlobalBattleInfo.OpDeck[0];
            print(IsPlayerDraw);
            print("是否我的回合" + GlobalBattleInfo.IsMyTurn);
            print("是否玩家1" + GlobalBattleInfo.IsPlayer1);
            print(@"\\\\\\\\\\\\\");

            //TargetCard.IsCanSee = GlobalBattleInfo.IsMyTurn ? IsPlayerDraw : !IsPlayerDraw;
            TargetCard.IsCanSee = IsPlayerDraw;
            if (IsPlayerDraw)
            {
                GlobalBattleInfo.MyDeck.Remove(TargetCard);
                GlobalBattleInfo.MyHand.Add(TargetCard);
            }
            else
            {
                GlobalBattleInfo.OpDeck.Remove(TargetCard);
                GlobalBattleInfo.OpHand.Add(TargetCard);
            }


            // GlobeBattleInfo.MyDeck.Add(TargetCard);
            // RowsInfo.GetRegionCardList(RegionName_Other.My_Deck).Remove(TargetCard);
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).Add(TargetCard);
            await Task.Delay(50);
        }
        public static async Task PlayCard()
        {
            SoundControl.Play();
            GameCommand.PlayCardLimit(true);
            Card TargetCard = GlobalBattleInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.Remove(TargetCard);
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Add(TargetCard);
            GlobalBattleInfo.MyHand.Remove(TargetCard);
            GlobalBattleInfo.MyUse.Add(TargetCard);
            //await CardEffectStack.TriggerEffect<TriggerType.Playcard>(TargetCard);
            GlobalBattleInfo.PlayerPlayCard = null;
            await TargetCard.Trigger<TriggerType.Deploy>();
            //await CardEffectStackControl.TriggerEffect<TriggerType.Deploy>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task DisCard(Card card = null)
        {
            Card TargetCard = card == null ? GlobalBattleInfo.PlayerPlayCard : card;
            TargetCard.IsPrePrepareToPlay = false;
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.Remove(TargetCard);
            TargetCard.Row.Remove(TargetCard);
            GlobalBattleInfo.MyGrave.Add(TargetCard);
            await TargetCard.Trigger<TriggerType.Discard>();
            //await CardEffectStackControl.TriggerEffect<TriggerType.Discard>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task Deploy()
        {
            //Card card = RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard[0];
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Remove(card);

            Card card = GlobalBattleInfo.MyUse[0];
            GlobalBattleInfo.MyUse.Remove(card);
            GlobalBattleInfo.SelectRegion.ThisRowCard.Insert(GlobalBattleInfo.SelectLocation, card);
            GlobalBattleInfo.SelectRegion = null;
            GlobalBattleInfo.SelectLocation = -1;
            //部署特效
            //print("duang");
            await Task.Delay(2000);
        }
    }
}