using Command;
using Info;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Control
{
    public class RowControl : MonoBehaviour
    {
        // Start is called before the first frame update
        SingleRowInfo SingleInfo;
        public float Range;
        //public float Detal = 1.6f;
        //public float Bias;
        public bool IsMyHandRegion;
        public bool IsSingle;


        void Awake()
        {
            SingleInfo = GetComponent<SingleRowInfo>();

        }

        // Update is called once per frame
        void Update()
        {
            ControlCardPosition(SingleInfo.ThisRowCard);
            RefreshHandCard(SingleInfo.ThisRowCard);
            TempCardControk();
            //if (Input.GetMouseButtonDown(0)&& CanBeSelected)
            //{
            //    print("打出位置为2:" + SingleInfo.JudgeRank(GlobeBattleInfo.FocusPoint, out float x));
            //    print("相对坐标为"+x);
            //}
        }
        public void TempCardControk()
        {
            if (SingleInfo.TempCard == null && SingleInfo.CanBeSelected && GlobeBattleInfo.PlayerFocusRegion == SingleInfo)
            {
                CreatTempCard();
            }
            if (SingleInfo.TempCard != null && SingleInfo.Rank != SingleInfo.ThisRowCard.IndexOf(SingleInfo.TempCard))
            {
                ChangeTempCard();
            }
            if (SingleInfo.TempCard != null  && (!SingleInfo.CanBeSelected||GlobeBattleInfo.PlayerFocusRegion != SingleInfo))
            {
                DestoryTempCard();
            }

        }
        public void CreatTempCard()
        {
            SingleInfo.TempCard = CardCommand.CreatCard(RowsInfo.GetRegionCardList(RegionName_Other.My_Uesd).ThisRowCard[0].CardId);
            SingleInfo.TempCard.IsTemp = true;
            SingleInfo.TempCard.IsCanSee = true;
            SingleInfo.ThisRowCard.Insert(SingleInfo.Rank, SingleInfo.TempCard);
            SingleInfo.TempCard.Init();
        }
        public void DestoryTempCard()
        {
            SingleInfo.ThisRowCard.Remove(SingleInfo.TempCard);
            Destroy(SingleInfo.TempCard.gameObject);
            SingleInfo.TempCard = null;
        }
        public void ChangeTempCard()
        {
            SingleInfo.ThisRowCard.Remove(SingleInfo.TempCard);
            SingleInfo.ThisRowCard.Insert(SingleInfo.Rank, SingleInfo.TempCard);
        }
        public void SetSelectable(bool Seleceable)
        {
            SingleInfo.CanBeSelected = Seleceable;
            transform.GetComponent<Renderer>().material.SetColor("_Color", SingleInfo.CanBeSelected ? SingleInfo.color : Color.black);
        }
        void RefreshHandCard(List<Card> ThisCardList)
        {
            if (IsMyHandRegion)
            {
                foreach (var item in ThisCardList)
                {

                    if (GlobeBattleInfo.PlayerFocusCard != null && item == GlobeBattleInfo.PlayerFocusCard && item.IsLimit == false)
                    {
                        item.IsPrePrepareToPlay = true;
                    }
                    else
                    {
                        item.IsPrePrepareToPlay = false;
                    }
                }
            }
        }
        void ControlCardPosition(List<Card> ThisCardList)
        {
            int Num = ThisCardList.Count;
            for (int i = 0; i < ThisCardList.Count; i++)
            {

                float Actual_Interval = Mathf.Min(Range / Num, 1.6f);
                float Actual_Bias = IsSingle ? 0 : (Mathf.Min(ThisCardList.Count, 6) - 1) * 0.8f;
                //Bias = Actual_Bias;
                Vector3 Actual_Offset_Up = transform.up * (0.2f + i * 0.01f) * (ThisCardList[i].IsPrePrepareToPlay ? 1.1f : 1); //transform.up * (1 + i * 0.1f);//Vector3.up * (1 + i * 0.1f);
                                                                                                                                // Vector3 Actual_Offset_Up = transform.up * i; //transform.up * (1 + i * 0.1f);//Vector3.up * (1 + i * 0.1f);
                Vector3 Actual_Offset_Forward = ThisCardList[i].IsPrePrepareToPlay ? -transform.forward * 0.5f : Vector3.zero;
                if (ThisCardList[i].IsAutoMove)
                {
                    ThisCardList[i].SetMoveTarget(transform.position + Vector3.left * (Actual_Interval * i - Actual_Bias) + Actual_Offset_Up + Actual_Offset_Forward, transform.eulerAngles);
                }
                else
                {
                    ThisCardList[i].SetMoveTarget(GlobeBattleInfo.DragToPoint, Vector3.zero);
                }
                ThisCardList[i].RefreshState();
            }
        }

    }
}

