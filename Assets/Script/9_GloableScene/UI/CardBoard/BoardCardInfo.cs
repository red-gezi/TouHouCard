using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCardInfo : MonoBehaviour
{
    public int Rank;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseClick()
    {
        if (Info.GlobalBattleInfo.SelectBoardCardIds.Contains(Rank))
        {
            Info.GlobalBattleInfo.SelectBoardCardIds.Remove(Rank);
            print("移除了一张牌");
        }
        else
        {
            Info.GlobalBattleInfo.SelectBoardCardIds.Add(Rank);
            //print("加入了一张牌");
        }
    }
}
