﻿using CardSpace;
using Control;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Info
{
    public class SingleRowInfo : MonoBehaviour
    {
        public RegionTypes region;
        public Belong belong;
        public List<Card> ThisRowCard=> belong== Belong.My? RowsInfo.GetDownCardList(region): RowsInfo.GetUpCardList(region);
        //public List<Card> ShowCardList;
        public bool CanBeSelected;
        public int Rank => this.JudgeRank(GlobalBattleInfo.FocusPoint);
        public Card TempCard;
        public RowControl Control => GetComponent<RowControl>();
        public Color color;
        //public void Init()
        //{
        //    ThisRowCard = RowsInfo.GetCardList(region.ToAmend());
        //}
    }
    
}
static partial class RowInfoExtend
{
    public static int JudgeRank(this Info.SingleRowInfo SingleInfo, Vector3 point)
    {
        int Rank = 0;
        float posx = -(point.x - SingleInfo.transform.position.x);
        int UniteNum = SingleInfo.ThisRowCard.Where(card => !card.IsTemp).Count();
        for (int i = 0; i < UniteNum; i++)
        {
            if (posx > i * 1.6 - (UniteNum - 1) * 0.8)
            {
                Rank = i + 1;
            }
        }
        return Rank;
    }
}