using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Info;
using Command;
using System.Threading.Tasks;
using System;

public class InteractiveControl : MonoBehaviour
{
    Ray ray;
 
    void Update()
    {

        GetFocusTarget();
        MouseEvent();
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
                    GlobeBattleInfo.PlayerFocusCard = Infos[i].transform.GetComponent<Card>();
                    break;
                }
                GlobeBattleInfo.PlayerFocusCard = null;
            }
            for (int i = 0; i < Infos.Length; i++)
            {
                if (Infos[i].transform.GetComponent<SingleRowInfo>() != null)
                {
                    GlobeBattleInfo.PlayerFocusRegion = Infos[i].transform.GetComponent<SingleRowInfo>();
                    break;
                }
                GlobeBattleInfo.PlayerFocusRegion = null;
            }
        }
    }

    private async Task MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("按下鼠标");
            if (GlobeBattleInfo.PlayerFocusCard != null && GlobeBattleInfo.PlayerFocusCard.IsPrePrepareToPlay)
            {
                GlobeBattleInfo.PlayerPlayCard = GlobeBattleInfo.PlayerFocusCard;
            }
            if ( GlobeBattleInfo.IsWaitForSelectRegion)
            {
                //print("选择区域");
                GlobeBattleInfo.SelectRegion = GlobeBattleInfo.PlayerFocusRegion;
            }
        }
        if (Input.GetMouseButton(0))
        {
            LayerMask mask = 1 << LayerMask.NameToLayer("Default");
            if (Physics.Raycast(ray, out RaycastHit HitInfo, 100, mask))
            {
                GlobeBattleInfo.DragToPoint = HitInfo.point;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (GlobeBattleInfo.PlayerPlayCard != null)
            {
                if (GlobeBattleInfo.PlayerFocusRegion != null)
                {
                   // print(GlobeBattleInfo.PlayerFocusRegion.name);
                    if (GlobeBattleInfo.PlayerFocusRegion.name == "我方_墓地")
                    {
                         CardCommand.DisCard();
                    }
                    else if (GlobeBattleInfo.PlayerFocusRegion.name == "我方_手牌")
                    {

                    }
                    else
                    {
                         CardCommand.PlayCard();
                    }
                }
                else
                {
                     CardCommand.PlayCard();
                }

                //Command.GameCommand.PlayCardToRegion();
            }
            //print("执行了");
            //GlobeBattleInfo.PlayerPlayCard = null;
        }
    }
}
