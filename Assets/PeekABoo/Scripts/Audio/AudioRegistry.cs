using System.Collections.Generic;
using CardboardCore.DI;
using UnityEngine;

namespace PeekABoo.Audio
{
    [Injectable]
    public class AudioRegistry : MonoBehaviour
    {
        private readonly List<AudioSource> sfxSources = new List<AudioSource>();

        public PeekABooMusic Music { get; private set; }

        public void RegisterMusicSource(PeekABooMusic music)
        {
            Music = music;
        }

        public void RegisterSFXSource(AudioSource source)
        {
            if (sfxSources.Contains(source))
            {
                return;
            }

            sfxSources.Add(source);
        }

        public void UnregisterSFXSource(AudioSource source)
        {
            if (!sfxSources.Contains(source))
            {
                return;
            }

            sfxSources.Remove(source);
        }
    }
}
