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
            RowsInfo.GetRegionCardList(RegionName_Other.My_Hand).ThisRowCard.ForEach(card => card.IsLimit = IsLimit);
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
            SetRegionSelectable(true);
            //根据卡牌属性触发可选择的区域
            await Task.Run(() =>
            {
                while (Info.GlobeBattleInfo.SelectLocation <0) { }
            });
            //关闭所有可选择的区域
            SetRegionSelectable(false);

            GlobeBattleInfo.IsWaitForSelectLocation = false;
           // print("选择完毕");
        }
        public static void SetRegionSelectable(bool CanBeSelected)
        {
            if (CanBeSelected)
            {
                bool IsMyTerritory = GlobeBattleInfo.MyUse.ThisRowCard[0].CardTerritory == Territory.My;
                switch (GlobeBattleInfo.MyUse.ThisRowCard[0].CardProperty)
                {
                    case Property.Water:
                        {
                            if (IsMyTerritory)
                            {
                                GlobeBattleInfo.MyWater.Control.SetSelectable(true);
                            }
                            else
                            {
                                GlobeBattleInfo.OpWater.Control.SetSelectable(true);
                            }
                        }
                        break;
                    case Property.Fire:
                        break;
                    case Property.Wind:
                        if (IsMyTerritory)
                        {
                            GlobeBattleInfo.MyWind.Control.SetSelectable(true);
                        }
                        else
                        {
                            GlobeBattleInfo.OpWind.Control.SetSelectable(true);
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
    }
}

