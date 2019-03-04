using Control;
using Info;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class CardCommand : MonoBehaviour
    {
        public static Card CreatCard(int id)
        {
            GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
            NewCard.AddComponent(CardLibrary.Instance.CardLibraryList[id].GetType());
            return NewCard.GetComponent<Card>();
        }
        public static async Task<Card> CreatCardAsync(int id)
        {
            CardInstanceControl.IsCreatCard = true;
            CardInstanceControl.CreatID = id;
            await Task.Run(() => { while (CardInstanceControl.CreatCard == null) { } });
            Card NewCard = CardInstanceControl.CreatCard;
            CardInstanceControl.CreatCard = null;
            return NewCard;
        }
        public static async Task DrawCard(bool IsPlayerDraw = true)
        {
            SoundControl.Play();
            //Card TargetCard = RowsInfo.GetRegionCardList(RegionName_Other.My_Deck)[0];
            Card TargetCard = IsPlayerDraw ? GlobalBattleInfo.MyDeck.ThisRowCard[0] : GlobalBattleInfo.OpDeck.ThisRowCard[0];
            //TargetCard.IsCanSee = GlobalBattleInfo.IsMyTurn ? IsPlayerDraw : !IsPlayerDraw;
            TargetCard.IsCanSee =IsPlayerDraw;
            if (IsPlayerDraw)
            {
                GlobalBattleInfo.MyDeck.ThisRowCard.Remove(TargetCard);
                GlobalBattleInfo.MyHand.ThisRowCard.Add(TargetCard);
            }
            else
            {
                GlobalBattleInfo.OpDeck.ThisRowCard.Remove(TargetCard);
                GlobalBattleInfo.OpHand.ThisRowCard.Add(TargetCard);
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
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.Remove(TargetCard);
            RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Add(TargetCard);
            //await CardEffectStack.TriggerEffect<TriggerType.Playcard>(TargetCard);
            GlobalBattleInfo.PlayerPlayCard = null;
            await CardEffectStackControl.TriggerEffect<TriggerType.Deploy>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task DisCard(Card card = null)
        {
            Card TargetCard = card == null ? GlobalBattleInfo.PlayerPlayCard : card;
            TargetCard.IsPrePrepareToPlay = false;
            //RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.Remove(TargetCard);
            TargetCard.Row.Remove(TargetCard);
            GlobalBattleInfo.MyGrave.ThisRowCard.Add(TargetCard);
            await CardEffectStackControl.TriggerEffect<TriggerType.Discard>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task Deploy()
        {
            Card card = RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard[0];

            RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Remove(card);
            GlobalBattleInfo.SelectRegion.ThisRowCard.Insert(GlobalBattleInfo.SelectLocation, card);
            GlobalBattleInfo.SelectRegion = null;
            GlobalBattleInfo.SelectLocation = -1;
            //部署特效
            //print("duang");
            await Task.Delay(2000);
        }
    }
}