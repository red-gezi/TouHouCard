using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointControl : MonoBehaviour
{
    public int DownShowPoint = 0;
    public int UpShowPoint = 0;
    public Text MyPoint;
    public Text OpPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DownShowPoint != Info.PointInfo.TotalDownPoint)
        {
            DownShowPoint = Info.PointInfo.TotalDownPoint;

            MyPoint.text = $"<color=yellow>{DownShowPoint}</color>";
            MyPoint.transform.localScale = Vector3.one* 1.5f;
            Invoke("Reset", 1);
        }
        if (UpShowPoint != Info.PointInfo.TotalUpPoint)
        {
            UpShowPoint = Info.PointInfo.TotalUpPoint;

            OpPoint.text = $"<color=yellow>{UpShowPoint}</color>";
            OpPoint.transform.localScale = Vector3.one * 1.5f;
            Invoke("Reset", 1);
        }
    }

    private void Reset()
    {
        MyPoint.transform.localScale = Vector3.one;
        OpPoint.transform.localScale = Vector3.one;
    }
}
