using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Info
{
    public class PointInfo : SerializedMonoBehaviour
    {
        [ShowInInspector]
        public static int DownWaterPoint => Info.RowsInfo.GetDownCardList(RegionTypes.Water).Where(card=>!card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int DownFirePoint => Info.RowsInfo.GetDownCardList(RegionTypes.Fire).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int DownWindPoint => Info.RowsInfo.GetDownCardList(RegionTypes.Wind).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int DownSoilPoint => Info.RowsInfo.GetDownCardList(RegionTypes.Soil).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int TotalDownPoint => DownWaterPoint + DownFirePoint + DownWindPoint + DownSoilPoint;
        [ShowInInspector]
        public static int UpWaterPoint => Info.RowsInfo.GetUpCardList(RegionTypes.Water).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int UpFirePoint => Info.RowsInfo.GetUpCardList(RegionTypes.Fire).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int UpWindPoint => Info.RowsInfo.GetUpCardList(RegionTypes.Wind).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int UpSoilPoint => Info.RowsInfo.GetUpCardList(RegionTypes.Soil).Where(card => !card.IsTemp).Select(card => card.CardPoint).Sum();
        [ShowInInspector]
        public static int TotalUpPoint => UpWaterPoint + UpFirePoint + UpWindPoint + UpSoilPoint;
    }

}
