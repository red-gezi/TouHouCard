using Info;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class GameCommand : MonoBehaviour
    {
        public static void InitDeck()
        {

        }
        public static void PlayCardToRegion()
        {
            if (GlobeBattleInfo.PlayerFocusRegion.ThisRowCard.Count < 5)
            {
                Card TargetCard = GlobeBattleInfo.PlayerPlayCard;
                TargetCard.IsPrePrepareToPlay = false;
                //RowsInfo.Instance.SingleOtherInfos[RegionName_Other.My_Hand].ThisRowCard.Remove(TargetCard);
                GlobeBattleInfo.PlayerFocusRegion.ThisRowCard.Add(TargetCard);
                GlobeBattleInfo.IsCardEffectCompleted = true;
            }
        }
        public static void PlayCardToGraveyard()
        {
            
        }
        /// <summary>
        /// 限制手牌被打出
        /// </summary>
        /// <param name="IsOpen"></param>
        public static void PlayCardLimit(bool IsLimit)
        {
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ForEach(card => card.IsLimit = IsLimit);
        }
        public static async Task WaitForSelectRegion()
        {
            //print("请选择");
            GlobeBattleInfo.IsWaitForSelectRegion = true;
            await Task.Run(() =>
            {
                while (Info.GlobeBattleInfo.SelectRegion == null) { }
            });
            GlobeBattleInfo.IsWaitForSelectRegion = false;
            //print("选择完毕");
        }
        public static async Task WaitForSelectLocation()
        {
           // print("请选择");
            GlobeBattleInfo.IsWaitForSelectLocation = true;
            await Task.Run(() =>
            {
                while (Info.GlobeBattleInfo.SelectLocation == null) { }
            });
            GlobeBattleInfo.IsWaitForSelectLocation = false;
           // print("选择完毕");
        }
    }
}

