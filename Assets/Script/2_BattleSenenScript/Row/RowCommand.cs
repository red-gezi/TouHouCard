using CardSpace;
using Info;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Command
{
    public class RowCommand : MonoBehaviour
    {
        public static void SetRegionSelectable(bool CanBeSelected)
        {
            if (CanBeSelected)
            {
                Card DeployCard = RowsInfo.GetMyCardList(RegionTypes.Uesd)[0];
                bool IsMyTerritory = (DeployCard.CardTerritory == Territory.My);
                switch (RowsInfo.GetMyCardList(RegionTypes.Uesd)[0].CardProperty)
                {
                    case Property.Water:
                        {
                            SetRowShow(IsMyTerritory ? RegionName_Battle.My_Water : RegionName_Battle.Op_Water);
                            break;
                        }
                    case Property.Fire:
                        {
                            SetRowShow(IsMyTerritory ? RegionName_Battle.My_Fire : RegionName_Battle.Op_Fire);
                            break;
                        }
                    case Property.Wind:
                        {
                            SetRowShow(IsMyTerritory ? RegionName_Battle.My_Wind : RegionName_Battle.Op_Wind);
                            break;
                        }
                    case Property.Soil:
                        {
                            SetRowShow(IsMyTerritory ? RegionName_Battle.My_Soil : RegionName_Battle.Op_Soil);
                            break;
                        }
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

