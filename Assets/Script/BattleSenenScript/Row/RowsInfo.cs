using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
namespace Info
{
    public class RowsInfo : SerializedMonoBehaviour
    {
        public static RowsInfo Instance;

        public Dictionary<RegionName_Battle, SingleRowInfo> SingleBattleInfos = new Dictionary<RegionName_Battle, SingleRowInfo>();
        public Dictionary<RegionName_Other, SingleRowInfo> SingleOtherInfos = new Dictionary<RegionName_Other, SingleRowInfo>();
        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;
        }
        public static List<Card> GetRegionCardList(RegionName_Battle region)
        {
            return Instance.SingleBattleInfos[region].ThisRowCard;
        }
        public static List<Card> GetRegionCardList(RegionName_Other region)
        {
            return Instance.SingleOtherInfos[region].ThisRowCard;

        }
        public static Vector2 GetLocation(Card TargetCard)
        {
            List<Card> TargetCardList=null;
            int RankX=-1;
            int RankY=-1;
            for (int i = 0; i < Instance.SingleBattleInfos.Count; i++)
            {
                if (Instance.SingleBattleInfos[(RegionName_Battle)i].ThisRowCard.Contains(TargetCard))
                {
                    TargetCardList = Instance.SingleBattleInfos[(RegionName_Battle)i].ThisRowCard;
                    RankX = i;
                }
            }
            if (TargetCardList != null)
            {
                RankY = TargetCardList.IndexOf(TargetCard);
            }
            for (int i = 0; i < Instance.SingleOtherInfos.Count; i++)
            {
                if (Instance.SingleOtherInfos[(RegionName_Other)i].ThisRowCard.Contains(TargetCard))
                {
                    TargetCardList = Instance.SingleOtherInfos[(RegionName_Other)i].ThisRowCard;
                    RankX = i;
                }
            }
            if (TargetCardList!=null)
            {
                RankY = TargetCardList.IndexOf(TargetCard);
            }
            return new Vector2(RankX, RankY);
        }
    }
}

