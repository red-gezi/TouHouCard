using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class SoundInfo : MonoBehaviour
    {
        public AudioClip Clips;
        int a = 5;
        public static SoundInfo Instance;
        public static AudioClip StaticClips => Instance.Clips;

        void Awake()
        {
            Instance = this;
        }
    }
}
