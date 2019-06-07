using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class UiInfo : MonoBehaviour
    {
        public GameObject NoticeBoard_model;
        public static GameObject NoticeBoard => Instance.NoticeBoard_model;
        public static string NoticeBoardTitle { get; set; }
        public static string CardBoardTitle { get; set; }

        public GameObject MyPass;
        public GameObject OpPass;
        public Transform ConstantInstance;
        public GameObject CardBoardInstance;
        public static Dictionary<int, Sprite> CardImage = new Dictionary<int, Sprite>();
        public GameObject CardInstanceModel;
        public static List<GameObject> ShowCardLIstOnBoard = new List<GameObject>();
        public static Transform Constant => Instance.ConstantInstance;
        public static GameObject CardModel => Instance.CardInstanceModel;
        public static GameObject CardBoard => Instance.CardBoardInstance;


        public static UiInfo Instance;

        private void Awake() => Instance = this;

    }
}

