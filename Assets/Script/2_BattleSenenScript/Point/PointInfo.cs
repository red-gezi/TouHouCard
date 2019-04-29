using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointInfo : SerializedMonoBehaviour
{
    [ShowInInspector]
    public static int MyWaterPoint => Info.RowsInfo.GetCardList(RegionType.My_Water).Select(card => card.CardPoint).Sum();
    [ShowInInspector]

    public static int MyFirePoint => Info.RowsInfo.GetCardList(RegionType.My_Fire).Select(card => card.CardPoint).Sum();
    [ShowInInspector]

    public static int MyWindPoint => Info.RowsInfo.GetCardList(RegionType.My_Wind).Select(card => card.CardPoint).Sum();
    [ShowInInspector]

    public static int MySoilPoint => Info.RowsInfo.GetCardList(RegionType.My_Soil).Select(card => card.CardPoint).Sum();
    [ShowInInspector]
    public static int OpWaterPoint => Info.RowsInfo.GetCardList(RegionType.Op_Water).Select(card => card.CardPoint).Sum();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
