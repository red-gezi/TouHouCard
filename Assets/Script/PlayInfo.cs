using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using static NetInfoModel;

namespace Info
{
    public class PlayInfo : SerializedMonoBehaviour
    {
        //public static PlayInfo Instance;
        //string Name = "gezi";
        [ShowInInspector]
        public static PlayerInfo MyInfo;
        [ShowInInspector]
        public static PlayerInfo OpInfo;
        //private void Awake()
        //{
        //    Instance = this;
        //}
    }
}

