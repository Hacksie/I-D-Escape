using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace HackedDesign
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private AudioSource jump;
        [SerializeField] private AudioSource letter;
        [SerializeField] private AudioSource phrase;
        [SerializeField] private AudioSource dead;

        public static AudioManager Instance { get; private set; }

        AudioManager() => Instance = this;

        public void PlayJump()
        {
            if (jump != null)
            {
                jump.Play();
            }
        }

        public void PlayLetterCollect()
        {
            if (letter != null)
            {
                letter.Play();
            }
        }

        public void PlayPhraseCollect()
        {
            if (phrase != null)
            {
                phrase.Play();
            }
        }

        public void PlayDead()
        {
            if (dead != null)
            {
                dead.Play();
            }
        }        

    }
}