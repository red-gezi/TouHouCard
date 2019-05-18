using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Control
{
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
        void Update()
        {
            if (IsNotify)
            {
                NoticeBoard.transform.GetChild(0).GetComponent<Text>().text = Text;
                NoticeBoard.SetActive(true);
                IsNotify = false;
                Invoke("CloseNotice", 2);
            }
        }
        private void CloseNotice() => NoticeBoard.SetActive(false);
    }
}