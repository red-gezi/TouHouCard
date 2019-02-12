using Info;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool IsMove;
    public Card yaya;
    public bool IsPrePrepareToPlay;
    /// <summary>
    /// 限制卡牌被打出
    /// </summary>
    public bool IsLimit = true;
    public bool IsAutoMove => this != GlobeBattleInfo.PlayerPlayCard;
    public Vector2 Location => RowsInfo.GetLocation(this);
    public Vector3 TargetPos;
    public Quaternion TargetEuler;

    public void SetMoveTarget(Vector3 TargetPosition, Quaternion TargetEulers)
    {
        TargetPos = TargetPosition;
        TargetEuler = TargetEulers;
    }
    public void RefreshState()
    {
        if (GlobeBattleInfo.PlayerFocusCard == this)
        {
            GetComponent<Renderer>().material.SetFloat("_IsFocus", 1);
            GetComponent<Renderer>().material.SetFloat("_IsRed", 0);
        }
        else if (GlobeBattleInfo.OpponentFocusCard == this)
        {
            GetComponent<Renderer>().material.SetFloat("_IsFocus", 1);
            GetComponent<Renderer>().material.SetFloat("_IsRed", 1);
        }
        else
        {
            GetComponent<Renderer>().material.SetFloat("_IsFocus", 0);
        }
        transform.position = new Vector3(transform.position.x, TargetPos.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 5);
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetEuler, Time.deltaTime * 10);
    }
}
