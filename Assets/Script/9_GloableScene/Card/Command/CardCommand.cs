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
            await WashCard();
            await DrawCard();
            CardBoardCommand.LoadCardList(RowsInfo.GetMyCardList(RegionTypes.Hand));
            //UiCommand.CardBoardReload();
        }
        public static async Task DrawCard(bool IsPlayerDraw = true,bool ActiveBlackList=false)
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
            await OrderCard();
            await Task.Delay(100);
        }
        //洗回牌库
        public static async Task WashCard(bool IsPlayerWash = true)
        {
            print("洗牌");
            if (IsPlayerWash)
            {
                int MaxCardRank = Info.RowsInfo.GetMyCardList(RegionTypes.Deck).Count;
                int CardRank = AiCommand.GetRandom(0, MaxCardRank);
                GlobalBattleInfo.SelectLocation = CardRank;
                GlobalBattleInfo.SelectRegion = RowsInfo.GetRegionCardList(RegionName_Other.My_Deck);
                GlobalBattleInfo.TargetCard = GlobalBattleInfo.SingleSelectCardOnBoard;
                GlobalBattleInfo.TargetCard.IsCanSee = false;
                await MoveCard();
            }
            else
            {
                //int MaxCardRank = Info.RowsInfo.GetDownCardList(RegionTypes.Hand).Count;
                //int CardRank = AiCommand.GetRandom(0, MaxCardRank);
                //GlobalBattleInfo.SelectLocation = CardRank;
                //GlobalBattleInfo.SelectRegion = RowsInfo.GetRegionCardList(RegionName_Other.My_Hand);
               
                //await MoveCard();

                

            }
            await Task.Delay(500);
        }
        public static async Task OrderCard(bool IsPlayerWash = true)
        {
             RowsInfo.GlobalCardList[1] = RowsInfo.GlobalCardList[1].OrderBy(card => card.CardPoint).ToList();
             RowsInfo.GlobalCardList[3] = RowsInfo.GlobalCardList[3].OrderBy(card => card.CardPoint).ToList();
             RowsInfo.GlobalCardList[10] = RowsInfo.GlobalCardList[10].OrderBy(card => card.CardPoint).ToList();
             RowsInfo.GlobalCardList[12] = RowsInfo.GlobalCardList[12].OrderBy(card => card.CardPoint).ToList();

        }
        public static async Task MoveCard()
        {


            Card TargetCard = GlobalBattleInfo.TargetCard;
            GlobalBattleInfo.TargetCard = null;
            List<Card> OriginRow = RowsInfo.GetRow(TargetCard);
            List<Card> TargetRow = GlobalBattleInfo.SelectRegion.ThisRowCard;
            print("移动卡牌从"+ OriginRow.Count+"到"+ TargetRow.Count);
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