using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using static NetInfoModel;

namespace Info
{
    /// <summary>
    /// 双方信息
    /// </summary>
    public class AllPlayerInfo : SerializedMonoBehaviour
    {
        [ShowInInspector]
        public static PlayerInfo Player1Info;
        [ShowInInspector]
        public static PlayerInfo Player2Info;
    }
}

