using Info;
using System.Collections;
using System.Collections.Generic;
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
        void Start()
        {
            SingleInfo = GetComponent<SingleRowInfo>();
        }

        // Update is called once per frame
        void Update()
        {
            ControlCardPosition(SingleInfo.ThisRowCard);
            RefreshHandCard(SingleInfo.ThisRowCard);
        }
        void RefreshHandCard(List<Card> ThisCardList)
        {
            if (IsMyHandRegion)
            {
                foreach (var item in ThisCardList)
                {

                    if (GlobeCardInfo.PlayerFocusCard != null && item == GlobeCardInfo.PlayerFocusCard)
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
                float Actual_Bias = IsSingle? 0 : (Mathf.Min(ThisCardList.Count, 8) - 1) * 0.8f;
                //Bias = Actual_Bias;
                Vector3 Actual_Offset_Up = transform.up * (0.2f - i * 0.01f); //transform.up * (1 + i * 0.1f);//Vector3.up * (1 + i * 0.1f);
                Vector3 Actual_Offset_Forward = ThisCardList[i].IsPrePrepareToPlay ? -transform.forward * 0.5f : Vector3.zero;
                if (ThisCardList[i].IsAutoMove)
                {
                    ThisCardList[i].SetMoveTarget(transform.position + Vector3.right * (Actual_Interval * i - Actual_Bias) + Actual_Offset_Up + Actual_Offset_Forward, transform.rotation);
                }
                else
                {
                    ThisCardList[i].SetMoveTarget(GlobeCardInfo.DragToPoint, Quaternion.Euler(0, 0, 0));
                }
                ThisCardList[i].RefreshState();
            }
        }
    }
}

