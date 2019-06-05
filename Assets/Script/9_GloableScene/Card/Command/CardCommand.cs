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
        public static async Task<Card> CreatCard(int id)
        {
            Info.GlobalBattleInfo.TargetCardID = id;
            Info.GlobalBattleInfo.IsCreatCard = true;

            await Task.Run(() => { while (Info.GlobalBattleInfo.CreatedCard == null) { } });
            Card NewCard = Info.GlobalBattleInfo.CreatedCard;
            Info.GlobalBattleInfo.CreatedCard = null;
            //print("异步生成卡牌");
            return NewCard;
        }
        public static async Task ExchangeCard(bool IsPlayerWash = true)
        {
            await DrawCard();
            await WashCard();
            await OrderCard();
            UiCommand.CardBoardReload();
        }
        public static async Task DrawCard(bool IsPlayerDraw = true)
        {
            SoundControl.Play();
            Card TargetCard = IsPlayerDraw ? RowsInfo.GetMyCardList(RegionTypes.Deck)[0] : RowsInfo.GetOpCardList(RegionTypes.Deck)[0];
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

            //await Task.Delay(50);
        }
        //洗回牌库
        public static async Task WashCard(bool IsPlayerWash = true)
        {
            if (IsPlayerWash)
            {
                int MaxCardRank = Info.RowsInfo.GetMyCardList(RegionTypes.Deck).Count;
                int CardRank = AiCommand.GetRandom(0, MaxCardRank);
                GlobalBattleInfo.SelectLocation = CardRank;
                GlobalBattleInfo.SelectRegion = RowsInfo.GetRegionCardList(RegionName_Other.My_Deck);
                GlobalBattleInfo.TargetCard = GlobalBattleInfo.SingleSelectCardOnBoard;
                CardBoardCommand.LoadCardList(RowsInfo.GetMyCardList(RegionTypes.Hand));
                print("开始洗掉我方的牌");
                await MoveCard();
            }
            else
            {
                int MaxCardRank = Info.RowsInfo.GetDownCardList(RegionTypes.Hand).Count;
                int CardRank = AiCommand.GetRandom(0, MaxCardRank);
                GlobalBattleInfo.SelectLocation = CardRank;
                GlobalBattleInfo.SelectRegion = RowsInfo.GetRegionCardList(RegionName_Other.My_Hand);
                CardBoardCommand.LoadCardList(RowsInfo.GetOpCardList(RegionTypes.Hand));
                await MoveCard();

                await Task.Delay(500);

            }
        }
        public static async Task OrderCard(bool IsPlayerWash = true)
        {
            RowsInfo.GetMyCardList(RegionTypes.Hand).Order();
            RowsInfo.GetOpCardList(RegionTypes.Hand).Order();
        }
        public static async Task MoveCard()
        {
            print("洗牌");

            Card TargetCard = GlobalBattleInfo.TargetCard;
            List<Card> OriginRow = RowsInfo.GetRow(TargetCard);
            List<Card> TargetRow = GlobalBattleInfo.SelectRegion.ThisRowCard;
            OriginRow.Remove(TargetCard);
            TargetRow.Insert(GlobalBattleInfo.SelectLocation, TargetCard);
            //GlobalBattleInfo.SelectLocation
            //GlobalBattleInfo.SelectRegion = RowsInfo.GetRegionCardList(RegionName_Other.My_Hand);
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