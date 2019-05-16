using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    public GameObject DialogueUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            if (!DialogueUI.activeSelf)
            {
                DialogueUI.SetActive(true);
                DialogueCommand.play(1, 1);
            }
            else
            {
                DialgueInfo.DialgueInfos.IsNext = true;
            }
           
        }
    }
}
