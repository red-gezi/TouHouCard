using Info;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class GameCommand : MonoBehaviour
    {
        public static void PlayCardToRegion()
        {
            if (GlobeCardInfo.PlayerFocusRegion.ThisRowCard.Count<5)
            {
                Card TargetCard = GlobeCardInfo.PlayerPlayCard;
                TargetCard.IsPrePrepareToPlay = false;
                //RowsInfo.Instance.SingleOtherInfos[RegionName_Other.My_Hand].ThisRowCard.Remove(TargetCard);
                GlobeCardInfo.PlayerFocusRegion.ThisRowCard.Add(TargetCard);
                GlobeBattleInfo.IsCardEffectCompleted = true;
            }        
        }
        public static void PlayCardToGraveyard()
        {

        }
        public static void WaitForSelectRegion()
        {

        }
        public static void WaitForSelectLocation()
        {

        }
    }
}

