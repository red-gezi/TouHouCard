using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class UiInfo : MonoBehaviour
    {
        public GameObject NoticeBoard_model;
        public static GameObject NoticeBoard => Instance.NoticeBoard_model;
        public static string NoticeBoardTitle;
        public GameObject MyPass;
        public GameObject OpPass;
        public Transform ConstantInstance;
        public GameObject CardBoardInstance;
        public enum CardBoardMode
        {
            Select,//多次选择模式
            ChangeCard,//单次抽卡模式
            Auto//无法操作模式
        }
        public GameObject CardInstanceModel;
        public static List<GameObject> ShowCardLIstOnBoard = new List<GameObject>();
        public static Transform Constant => Instance.ConstantInstance;
        public static GameObject CardModel => Instance.CardInstanceModel;
        public static GameObject CardBoard => Instance.CardBoardInstance;
        public static UiInfo Instance;

        private void Awake() => Instance = this;

    }
}

