using Info;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            //print("请选择");
            GlobalBattleInfo.IsWaitForSelectRegion = true;
            await Task.Run(() =>
            {
                while (Info.GlobalBattleInfo.SelectRegion == null) { }
            });
            GlobalBattleInfo.IsWaitForSelectRegion = false;
            //print("选择完毕");
        }
        public static async Task WaitForSelectLocation()
        {
            // print("请选择");
            GlobalBattleInfo.IsWaitForSelectLocation = true;
            SetRegionSelectable(true);
            //根据卡牌属性触发可选择的区域
            await Task.Run(() =>
            {
                while (Info.GlobalBattleInfo.SelectLocation < 0) { }
            });
            //关闭所有可选择的区域
            SetRegionSelectable(false);

            GlobalBattleInfo.IsWaitForSelectLocation = false;
            // print("选择完毕");
        }
        public static void SetRegionSelectable(bool CanBeSelected)
        {
            if (CanBeSelected)
            {
                bool IsMyTerritory = GlobalBattleInfo.MyUse[0].CardTerritory == Territory.My;
                switch (GlobalBattleInfo.MyUse[0].CardProperty)
                {
                    case Property.Water:
                        {
                            SetRowShow(IsMyTerritory ? RegionName_Battle.My_Water : RegionName_Battle.Op_Water);
                        }
                        break;
                    case Property.Fire:
                        break;
                    case Property.Wind:
                        if (IsMyTerritory)
                        {
                            //GlobalBattleInfo.MyWind.Control.SetSelectable(true);
                        }
                        else
                        {
                            //GlobalBattleInfo.OpWind.Control.SetSelectable(true);
                        }
                        break;
                    case Property.Soil:
                        break;
                    case Property.None:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                RowsInfo.Instance.SingleBattleInfos.Values.ToList().ForEach(row => row.Control.SetSelectable(false));
            }
        }

        private static void SetRowShow(RegionName_Battle row)
        {
            RowsInfo.GetRegionCardList(row).Control.SetSelectable(true);
        }
    }
}

