using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Info;
using Command;
using System.Threading.Tasks;
using System;
using CardSpace;

namespace Control
{
    public class InteractiveControl : MonoBehaviour
    {
        Ray ray;
       public float PassPressTime;
        void Update()
        {
            GetFocusTarget();
            MouseEvent();
            KeyBoardEvent();
        }

       

        private void GetFocusTarget()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] Infos = Physics.RaycastAll(ray);
            if (Infos.Length > 0)
            {
                for (int i = 0; i < Infos.Length; i++)
                {
                    if (Infos[i].transform.GetComponent<Card>() != null)
                    {
                        GlobalBattleInfo.PlayerFocusCard = Infos[i].transform.GetComponent<Card>();
                        break;
                    }
                    GlobalBattleInfo.PlayerFocusCard = null;
                }
                for (int i = 0; i < Infos.Length; i++)
                {
                    if (Infos[i].transform.GetComponent<SingleRowInfo>() != null)
                    {
                        GlobalBattleInfo.PlayerFocusRegion = Infos[i].transform.GetComponent<SingleRowInfo>();
                        GlobalBattleInfo.FocusPoint = Infos[i].point;
                        break;
                    }
                    GlobalBattleInfo.PlayerFocusRegion = null;
                }
            }
        }
        private  void KeyBoardEvent()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                PassPressTime += Time.deltaTime;
                if (PassPressTime>2)
                {
                    PassCommand.SetCurrentPass();
                    PassPressTime = 0;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                PassPressTime =0;
            }
        }
        private void MouseEvent()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (GlobalBattleInfo.PlayerFocusCard != null && GlobalBattleInfo.PlayerFocusCard.IsPrePrepareToPlay)
                {
                    GlobalBattleInfo.PlayerPlayCard = GlobalBattleInfo.PlayerFocusCard;
                }
                if (GlobalBattleInfo.IsWaitForSelectRegion)
                {
                    GlobalBattleInfo.SelectRegion = GlobalBattleInfo.PlayerFocusRegion;
                }
                if (GlobalBattleInfo.IsWaitForSelectLocation)
                {
                    if (GlobalBattleInfo.PlayerFocusRegion != null && GlobalBattleInfo.PlayerFocusRegion.CanBeSelected)
                    {
                        //print("选择位置" + GlobalBattleInfo.PlayerFocusRegion.Rank);
                        GlobalBattleInfo.SelectRegion = GlobalBattleInfo.PlayerFocusRegion;
                        GlobalBattleInfo.SelectLocation = GlobalBattleInfo.PlayerFocusRegion.Rank;
                    }
                }
               // print($"所在行为{GlobalBattleInfo.PlayerFocusCard.Row}，所在坐标为{GlobalBattleInfo.PlayerFocusCard.Location}");
            }
            if (Input.GetMouseButton(0))
            {
                LayerMask mask = 1 << LayerMask.NameToLayer("Default");
                if (Physics.Raycast(ray, out RaycastHit HitInfo, 100, mask))
                {
                    GlobalBattleInfo.DragToPoint = HitInfo.point;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (GlobalBattleInfo.PlayerPlayCard != null)
                {
                    if (GlobalBattleInfo.PlayerFocusRegion != null)
                    {
                        if (GlobalBattleInfo.PlayerFocusRegion.name == "我方_墓地")
                        {
                            _ = CardCommand.DisCard();
                        }
                        else if (GlobalBattleInfo.PlayerFocusRegion.name == "我方_手牌")
                        {
                            GlobalBattleInfo.PlayerPlayCard = null;
                        }
                        else
                        {
                            _ = CardCommand.PlayCard();
                        }
                    }
                    else
                    {
                        _ = CardCommand.PlayCard();
                    }
                }
            }
        }
    }
}