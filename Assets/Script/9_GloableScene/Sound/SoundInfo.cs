using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Info
{
    public class SoundInfo : MonoBehaviour
    {
        public AudioClip Clips;
        public static SoundInfo Instance;
        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
