using Info;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Info
{
    public class SingleRowInfo : MonoBehaviour
    {
        public List<Card> ThisRowCard = new List<Card>();
        public int Rank => this.JudgeRank(GlobeBattleInfo.FocusPoint);
        public Card TempCard;
    }
    static class RowInfoExtend
    {
        public static int JudgeRank(this SingleRowInfo SingleInfo, Vector3 point)
        {
            int Rank = 0;
            float posx = (point.x - SingleInfo.transform.position.x);
            //x = posx;
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
}