using CardboardCore.DI;
using DG.Tweening;
using UnityEngine;

namespace PeekABoo.Audio
{
    public class PeekABooMusic : CardboardCoreBehaviour
    {
        [Inject] private AudioRegistry audioRegistry;

        [SerializeField] private AudioClip introMusic;

        private AudioSource audioSource;

        protected override void OnInjected()
        {
            audioSource = GetComponent<AudioSource>();
            audioRegistry.RegisterMusicSource(this);
        }

        protected override void OnReleased()
        {

        }

        public void Play()
        {
            audioSource.Play();
        }

        public void Stop()
        {
            audioSource.Stop();
        }

        public void Pause()
        {
            audioSource.Pause();
        }

        public void Resume()
        {
            audioSource.UnPause();
        }

        public void SetVolume(float volume)
        {
            audioSource.volume = volume;
        }

        public void PlayIntroMusic()
        {
            audioSource.clip = introMusic;
            Play();
        }

        public void FadeOut(float duration)
        {
            audioSource.DOFade(0, duration);
        }
    }
}
