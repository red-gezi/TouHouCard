using Info;
using UnityEngine;
namespace Control
{
    public class SoundControl : MonoBehaviour
    {
        public static SoundControl Instance;
        static bool IsPlay;
        public static void Play()
        {
            IsPlay = true;
        }
        public void PlayAudioEffect()
        {
            AudioSource Source = gameObject.AddComponent<AudioSource>();
            Source.clip = SoundInfo.Instance.Clips;
            Source.Play();
            Destroy(Source, Source.clip.length);
        }
        void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            if (IsPlay)
            {
                PlayAudioEffect();
                IsPlay = false;
            }
        }
    }
}