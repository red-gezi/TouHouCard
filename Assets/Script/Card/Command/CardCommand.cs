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
        public static Card CreatCard(int id, Vector3 Position)
        {
            //print("开始创建");
            //print(CardLibrary.Instance);
            GameObject NewCard = Instantiate(CardLibrary.Instance.Card_Model);
            NewCard.transform.position = Position;
            //print(NewCard.name);
            NewCard.AddComponent(CardLibrary.Instance.CardLibraryList[id].GetType());
            return NewCard.GetComponent<Card>();
        }
        public static async Task DrawCard()
        {
            SoundControl.Play();
            Card TargetCard = RowsInfo.GetRegionCardList(RegionName_Other.My_Deck)[0];
            RowsInfo.GetRegionCardList(RegionName_Other.My_Deck).Remove(TargetCard);
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).Add(TargetCard);
            await Task.Delay(100);
        }
        public static async Task PlayCard()
        {
            SoundControl.Play();
            GameCommand.PlayCardLimit(true);
            Card TargetCard = GlobeBattleInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).Remove(TargetCard);
            RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).Add(TargetCard);
            //await CardEffectStack.TriggerEffect<TriggerType.Playcard>(TargetCard);
            GlobeBattleInfo.PlayerPlayCard = null;
            await CardEffectStackControl.TriggerEffect<TriggerType.Deploy>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task DisCard()
        {
            Card TargetCard = GlobeBattleInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).Remove(TargetCard);
            GlobeBattleInfo.PlayerFocusRegion.ThisRowCard.Add(TargetCard);
            await CardEffectStackControl.TriggerEffect<TriggerType.Discard>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task Deploy()
        {
            Card card = RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd)[0];

            RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).Remove(card);
            GlobeBattleInfo.SelectRegion.ThisRowCard.Insert(GlobeBattleInfo.SelectLocation,card);
            GlobeBattleInfo.SelectRegion = null;
            GlobeBattleInfo.SelectLocation = -1;
            //部署特效
            //print("duang");
            await Task.Delay(2000);
        }
    }
}