using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NoticeControl : MonoBehaviour
{
    public GameObject NoticeBoard;
    static bool IsNotify;
    static string Text;
    public static void BoardNotice(string text)
    {
        Text = text;
        IsNotify = true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsNotify)
        {
            NoticeBoard.transform.GetChild(0).GetComponent<Text>().text = Text;
            NoticeBoard.SetActive(true);
            IsNotify = false;

            Invoke("CloseNotice", 1);

        }
    }

    private void CloseNotice()
    {
        NoticeBoard.SetActive(false);
    }
}
