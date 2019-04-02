using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using static NetInfoModel;

namespace Info
{
    public class AllPlayerInfo : SerializedMonoBehaviour
    {
        [ShowInInspector]
        public static PlayerInfo MyInfo;
        [ShowInInspector]
        public static PlayerInfo OpInfo;
    }
}

