using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class SoundInfo : MonoBehaviour
    {
        public AudioClip Clips;
        public static SoundInfo Instance;
        void Awake()
        {
            Instance = this;
        }
    }
}
