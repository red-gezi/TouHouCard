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
            Card TargetCard = IsPlayerDraw ? GlobeBattleInfo.MyDeck.ThisRowCard[0] : GlobeBattleInfo.OpDeck.ThisRowCard[0];
            TargetCard.IsCanSee = GlobeBattleInfo.IsMyTurn ? IsPlayerDraw : !IsPlayerDraw;
            if (IsPlayerDraw)
            {
                GlobeBattleInfo.MyDeck.ThisRowCard.Remove(TargetCard);
                GlobeBattleInfo.MyHand.ThisRowCard.Add(TargetCard);
            }
            else
            {
                GlobeBattleInfo.OpDeck.ThisRowCard.Remove(TargetCard);
                GlobeBattleInfo.OpHand.ThisRowCard.Add(TargetCard);
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
            Card TargetCard = GlobeBattleInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.Remove(TargetCard);
            RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Add(TargetCard);
            //await CardEffectStack.TriggerEffect<TriggerType.Playcard>(TargetCard);
            GlobeBattleInfo.PlayerPlayCard = null;
            await CardEffectStackControl.TriggerEffect<TriggerType.Deploy>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task DisCard()
        {
            Card TargetCard = GlobeBattleInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.Remove(TargetCard);
            GlobeBattleInfo.PlayerFocusRegion.ThisRowCard.Add(TargetCard);
            await CardEffectStackControl.TriggerEffect<TriggerType.Discard>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task Deploy()
        {
            Card card = RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard[0];

            RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard.Remove(card);
            GlobeBattleInfo.SelectRegion.ThisRowCard.Insert(GlobeBattleInfo.SelectLocation, card);
            GlobeBattleInfo.SelectRegion = null;
            GlobeBattleInfo.SelectLocation = -1;
            //部署特效
            //print("duang");
            await Task.Delay(2000);
        }
    }
}