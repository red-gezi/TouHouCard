using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class UiInfo : MonoBehaviour
    {
        public GameObject MyPass;
        public GameObject OpPass;
        public static UiInfo Instance;
        private void Awake()
        {
            Instance = this;
        }
        
    }
}

