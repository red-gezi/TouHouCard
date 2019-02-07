using Info;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool IsMove;
    public Card yaya;
    public bool IsPrePrepareToPlay;
    public bool IsAutoMove => this != GlobeCardInfo.PlayerPlayCard;
    public Vector3 TargetPos;
    public Quaternion TargetEuler;
    
    public void SetMoveTarget(Vector3 TargetPosition, Quaternion TargetEulers)
    {
        TargetPos = TargetPosition;
        TargetEuler = TargetEulers;
    }
    public void RefreshState()
    {
        if (GlobeCardInfo.PlayerFocusCard==this)
        {
            GetComponent<Renderer>().material.SetFloat("_IsFocus", 1);
            GetComponent<Renderer>().material.SetFloat("_IsRed", 0);
        }
        else if (GlobeCardInfo.OpponentFocusCard == this)
        {
            GetComponent<Renderer>().material.SetFloat("_IsFocus", 1);
            GetComponent<Renderer>().material.SetFloat("_IsRed", 1);
        }
        else
        {
            GetComponent<Renderer>().material.SetFloat("_IsFocus", 0);
        }
        transform.position = new Vector3(transform.position.x,TargetPos.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 5);
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetEuler, Time.deltaTime * 10);
    }
}
