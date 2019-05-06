using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointInfo : SerializedMonoBehaviour
{
    [ShowInInspector]
    public static int DownWaterPoint => Info.RowsInfo.GetDownCardList(RegionTypes.Water).Select(card => card.CardPoint).Sum();
    [ShowInInspector]
    public static int DownFirePoint => Info.RowsInfo.GetDownCardList(RegionTypes.Fire).Select(card => card.CardPoint).Sum();
    [ShowInInspector]
    public static int DownWindPoint => Info.RowsInfo.GetDownCardList(RegionTypes.Wind).Select(card => card.CardPoint).Sum();
    [ShowInInspector]
    public static int DownSoilPoint => Info.RowsInfo.GetDownCardList(RegionTypes.Soil).Select(card => card.CardPoint).Sum();
    [ShowInInspector]
    public static int UpWaterPoint => Info.RowsInfo.GetUpCardList(RegionTypes.Water).Select(card => card.CardPoint).Sum();
}
