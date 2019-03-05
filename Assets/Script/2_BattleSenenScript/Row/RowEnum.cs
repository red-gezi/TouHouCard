//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RowEnum 
//{

//}
public enum RegionName_Battle
{
    My_Water,
    My_Fire,
    My_Wind,
    My_Soil,
    Op_Water,
    Op_Fire,
    Op_Wind,
    Op_Soil,
}
public enum RegionName_Other
{
    My_Leader,
    My_Hand,
    My_Uesd,
    My_Deck,
    My_Grave,
    Op_Leader,
    Op_Hand,
    Op_Uesd,
    Op_Deck,
    Op_Grave,
}
public enum RegionType
{
    My_Leader,
    My_Hand,
    My_Uesd,
    My_Deck,
    My_Grave,
    My_Water,
    My_Fire,
    My_Wind,
    My_Soil,
    Op_Leader,
    Op_Hand,
    Op_Uesd,
    Op_Deck,
    Op_Grave,
    Op_Water,
    Op_Fire,
    Op_Wind,
    Op_Soil,
}
static class RegionTypeExtened
{
    public static RegionType ToAmend(this RegionType type)
    {
        int RegionNum = (int)type;
        if (Info.GlobalBattleInfo.IsRevertRows)
        {
            if (RegionNum >= 9)
            {
                RegionNum -= 9;
            }
            else
            {
                RegionNum += 9;

            }
        }
        return (RegionType)RegionNum;
    }
}
