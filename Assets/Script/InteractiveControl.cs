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
                    GlobeCardInfo.PlayerFocusCard = Infos[i].transform.GetComponent<Card>();
                    break;
                }
                GlobeCardInfo.PlayerFocusCard = null;
            }
            for (int i = 0; i < Infos.Length; i++)
            {
                if (Infos[i].transform.GetComponent<SingleRowInfo>() != null)
                {
                    GlobeCardInfo.PlayerFocusRegion = Infos[i].transform.GetComponent<SingleRowInfo>();
                    break;
                }
                GlobeCardInfo.PlayerFocusRegion = null;
            }
        }
    }

    private async Task MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GlobeCardInfo.PlayerFocusCard != null && GlobeCardInfo.PlayerFocusCard.IsPrePrepareToPlay)
            {
                GlobeCardInfo.PlayerPlayCard = GlobeCardInfo.PlayerFocusCard;
            }
        }
        if (Input.GetMouseButton(0))
        {
            LayerMask mask = 1 << LayerMask.NameToLayer("Default");
            if (Physics.Raycast(ray, out RaycastHit HitInfo, 100, mask))
            {
                GlobeCardInfo.DragToPoint = HitInfo.point;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (GlobeCardInfo.PlayerPlayCard != null)
            {
                if (GlobeCardInfo.PlayerFocusRegion != null)
                {
                    print(GlobeCardInfo.PlayerFocusRegion.name);
                    if (GlobeCardInfo.PlayerFocusRegion.name == "我方_墓地")
                    {
                        await CardCommand.DisCard();
                    }
                    else if (GlobeCardInfo.PlayerFocusRegion.name == "我方_手牌")
                    {

                    }
                    else
                    {
                        await CardCommand.PlayCard();
                    }
                }
                else
                {
                    await CardCommand.PlayCard();
                }

                //Command.GameCommand.PlayCardToRegion();
            }
            print("执行了");
            GlobeCardInfo.PlayerPlayCard = null;
        }
    }
}
