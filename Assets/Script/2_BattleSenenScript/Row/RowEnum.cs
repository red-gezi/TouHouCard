//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RowEnum 
//{

//}
using System;

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
public enum RegionTypes
{
   Leader,
   Hand,
   Uesd,
   Deck,
   Grave,
   Water,
   Fire,
   Wind,
   Soil,
}
public enum Orientation
{
    /// <summary>
    /// 对战上方区域
    /// </summary>
    Up,
    /// <summary>
    /// 对战下方区域
    /// </summary>
    Down,
    /// <summary>
    /// 使用卡牌所属方区域
    /// </summary>
    My,
    /// <summary>
    /// 使用卡牌对手方区域
    /// </summary>
    Op
}
public enum Belong
{
    /// <summary>
    /// 使用卡牌所属方区域
    /// </summary>
    My,
    /// <summary>
    /// 使用卡牌对手方区域
    /// </summary>
    Op
}
[Obsolete("即将重构")]
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
    //public static RegionType ToAmend(this RegionType type)
    //{
    //    int RegionNum = (int)type;
    //    if (Info.GlobalBattleInfo.IsRevertRows)
    //    {
    //        //if (RegionNum >= 9)
    //        //{
    //        //    RegionNum -= 9;
    //        //}
    //        //else
    //        //{
    //        //    RegionNum += 9;
    //        //}
    //        RegionNum = RegionNum >= 9 ? RegionNum - 9 : RegionNum + 9;
    //    }
    //    return (RegionType)RegionNum;
    //}
}
