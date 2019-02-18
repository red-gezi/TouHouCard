using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Info
{
    public class PlayInfo : SerializedMonoBehaviour
    {
        public static PlayInfo Instance;
        string Name = "gezi";
        public CardDeck MyDeck;
        public CardDeck OpDeck;
        private void Awake()
        {
            Instance = this;
        }
    }
}

