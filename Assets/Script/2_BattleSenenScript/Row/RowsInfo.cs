using CardSpace;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Info
{
    public class RowsInfo : SerializedMonoBehaviour
    {
        [ShowInInspector]
        public static List<List<Card>> GlobalCardList = new List<List<Card>>();
        public static RowsInfo Instance;

        public Dictionary<RegionName_Battle, SingleRowInfo> SingleBattleInfos = new Dictionary<RegionName_Battle, SingleRowInfo>();
        public Dictionary<RegionName_Other, SingleRowInfo> SingleOtherInfos = new Dictionary<RegionName_Other, SingleRowInfo>();
        void Awake() => Init();
        public  void Init()
        {
            Instance = this;
            GlobalCardList.Clear();
            for (int i = 0; i < 18; i++)
            {
                GlobalCardList.Add(new List<Card>());
            }
        }

        public static List<Card> GetUpCardList(RegionTypes type)
        {
            return GlobalCardList[(int)type + (GlobalBattleInfo.IsPlayer1 ? 9 : 0)];
        }
        public static List<Card> GetDownCardList(RegionTypes type)
        {
            return GlobalCardList[(int)type + (GlobalBattleInfo.IsPlayer1 ? 0 : 9)];
        }
        public static List<Card> GetMyCardList(RegionTypes type)
        {
            if (GlobalBattleInfo.IsMyTurn)
            {
                return GetDownCardList(type);
            }
            else
            {
                return GetUpCardList(type);
            }
        }
        public static List<Card> GetOpCardList(RegionTypes type)
        {
            if (GlobalBattleInfo.IsMyTurn)
            {
                return GetUpCardList(type);
            }
            else
            {
                return GetDownCardList(type);
            }
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

