using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class CardBoardInfo : MonoBehaviour
    {
        static CardBoardInfo Instance;
        private void Awake() => Instance = this;

        public Transform ConstantInstance;
        public GameObject CardBoardInstance;
        public GameObject CardInstanceModel;
        public static List<GameObject> ShowBoardCardLIst = new List<GameObject>();
        public static Transform Constant => Instance.ConstantInstance;
        public static GameObject CardModel => Instance.CardInstanceModel;
        public static GameObject CardBoard => Instance.CardBoardInstance;
    }
}

