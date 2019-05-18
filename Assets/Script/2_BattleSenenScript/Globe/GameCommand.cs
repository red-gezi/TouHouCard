using CardSpace;
using Info;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
namespace Command
{
    public class GameCommand 
    {
        public static void InitDeck()
        {

        }
        public static void PlayCardToRegion()
        {
            if (GlobalBattleInfo.PlayerFocusRegion.ThisRowCard.Count < 5)
            {
                Card TargetCard = GlobalBattleInfo.PlayerPlayCard;
                TargetCard.IsPrePrepareToPlay = false;
                //RowsInfo.Instance.SingleOtherInfos[RegionName_Other.My_Hand].ThisRowCard.Remove(TargetCard);
                GlobalBattleInfo.PlayerFocusRegion.ThisRowCard.Add(TargetCard);
                GlobalBattleInfo.IsCardEffectCompleted = true;
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
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.ForEach(card => card.IsLimit = IsLimit);
        }
        public static async Task WaitForSelectRegion()
        {
            GlobalBattleInfo.IsWaitForSelectRegion = true;
            await Task.Run(() =>
            {
                while (Info.GlobalBattleInfo.SelectRegion == null) { }
            });
            GlobalBattleInfo.IsWaitForSelectRegion = false;
        }
        public static async Task WaitForSelectLocation()
        {
            GlobalBattleInfo.IsWaitForSelectLocation = true;
            RowCommand.SetRegionSelectable(true);
            await Task.Run(() =>
            {
                while (Info.GlobalBattleInfo.SelectLocation < 0) { }
            });
            RowCommand.SetRegionSelectable(false);
            GlobalBattleInfo.IsWaitForSelectLocation = false;
        }
    }
}

