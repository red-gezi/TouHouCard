using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointControl : MonoBehaviour
{
    public int ShowPoint = 0;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ShowPoint != Info.PointInfo.DownWaterPoint)
        {
            ShowPoint = Info.PointInfo.DownWaterPoint;

            text.text = $"<color=yellow>{ShowPoint}</color>";
            text.transform.localScale = Vector3.one* 1.5f;
            Invoke("Reset", 1);
        }
    }

    private void Reset()
    {
        text.transform.localScale = Vector3.one;
    }
}
