using Info;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{

    public class CardCommand : MonoBehaviour
    {
        public static async Task PlayCard()
        {
            Card TargetCard = GlobeCardInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetRegion(RegionName_Other.My_Hand).Remove(TargetCard);
            RowsInfo.GetRegion(RegionName_Other.My_Uesd).Add(TargetCard);
            //await CardEffectStack.TriggerEffect<TriggerType.Playcard>(TargetCard);
            GlobeCardInfo.PlayerPlayCard = null;
            await CardEffectStack.TriggerEffect<TriggerType.Deploy>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
        public static async Task DisCard()
        {
            Card TargetCard = GlobeCardInfo.PlayerPlayCard;
            TargetCard.IsPrePrepareToPlay = false;
            RowsInfo.GetRegion(RegionName_Other.My_Hand).Remove(TargetCard);
            GlobeCardInfo.PlayerFocusRegion.ThisRowCard.Add(TargetCard);
            await CardEffectStack.TriggerEffect<TriggerType.Discard>(TargetCard);
            //GlobeBattleInfo.IsCardEffectCompleted = true;
        }
    }
}