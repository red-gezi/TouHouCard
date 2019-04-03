﻿using CardSpace;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Info
{
    public class RowsInfo : SerializedMonoBehaviour
    {
        [ShowInInspector]
        static List<List<Card>> GlobalCardList = new List<List<Card>>();
        public static RowsInfo Instance;

        public Dictionary<RegionName_Battle, SingleRowInfo> SingleBattleInfos = new Dictionary<RegionName_Battle, SingleRowInfo>();
        public Dictionary<RegionName_Other, SingleRowInfo> SingleOtherInfos = new Dictionary<RegionName_Other, SingleRowInfo>();
        void Awake()
        {
            Instance = this;
            Init();
            for (int i = 0; i < 18; i++)
            {
                print((RegionType)i + ":" + ((RegionType)i).ToAmend());
                SingleBattleInfos.Values.ToList().ForEach(row => row.Init());
                SingleOtherInfos.Values.ToList().ForEach(row => row.Init());
            }
        }
        public static void Init()
        {
            GlobalCardList.Clear();
            for (int i = 0; i < 18; i++)
            {
                GlobalCardList.Add(new List<Card>());
            }
        }
        public static List<Card> GetCardList(RegionType type)
        {
            return GlobalCardList[(int)type];
        }

        public static SingleRowInfo GetRegionCardList(RegionName_Battle region)
        {
            return Instance.SingleBattleInfos[region];
        }

        public static SingleRowInfo GetRegionCardList(RegionName_Other region)
        {
            return Instance.SingleOtherInfos[region];
        }

        public static Vector2 GetLocation(Card TargetCard)
        {
            int RankX = -1;
            int RankY = -1;
            for (int i = 0; i < GlobalCardList.Count; i++)
            {
                if (GlobalCardList[i].Contains(TargetCard))
                {
                    RankX = i;
                    RankY = GlobalCardList[i].IndexOf(TargetCard);
                }
            }
            return new Vector2(RankX, RankY);
        }
        public static List<Card> GetRow(Card TargetCard)
        {
            List<Card> TargetCardList = null;
            foreach (var cardlist in GlobalCardList)
            {
                if (cardlist.Contains(TargetCard))
                {
                    TargetCardList = cardlist;
                }
            }
            return TargetCardList;
        }
    }
}

