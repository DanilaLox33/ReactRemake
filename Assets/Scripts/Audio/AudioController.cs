using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Features.Game
{
    /// <summary>
    /// ����� ��� ������ �� ������.
    /// </summary>
    public sealed class AudioController : MonoBehaviour
    {
        [Header("Music setting")]
        [SerializeField] private AudioSource _musicMixer;
        [SerializeField] private List<AudioClip> _misicClips = new List<AudioClip>();

        [Header("Sound setting")]
        [SerializeField] private AudioSource _soundMixer;
        [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();

        [SerializeField] private string startTrack = string.Empty;
        

        public float MusicVolume { get => _musicMixer.volume; private set => _musicMixer.volume = value; }
        public float SoundVolume { get => _soundMixer.volume; private set => _soundMixer.volume = value; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            SetMusic(startTrack);
        }

        public void SetMusic(string audioName)
        {
            var sound = _misicClips.FirstOrDefault(clip => clip.name == audioName);
            if (!sound)
            {
                Debug.LogWarning($"AudioController: Sound '{audioName}' not found");
                return;
            }

            _musicMixer.clip = sound;
            _musicMixer.Play();
        }

        /// <summary>
        /// ������ ���� �� ��������.
        /// </summary>
        /// <param name="audioName">�������� �����.</param>
        public void SetSound(string audioName)
        {
            var sound = _audioClips.FirstOrDefault(clip => clip.name == audioName);
            if (!sound)
            {
                Debug.LogWarning($"AudioController: Sound '{audioName}' not found");
                return;
            }

            _soundMixer.clip = sound;
            _soundMixer.PlayOneShot(sound);
        }

        /// <summary>
        /// ������ ����.
        /// </summary>
        /// <param name="value">�������� �����.</param>
        public void SetPitch(float value)
        {
            _soundMixer.pitch = value;
        }

        /// <summary>
        /// ���������� ��������� �����.
        /// </summary>
        /// <param name="value">���������</param>
        public void SetSoundVolume(float value)
        {
            _soundMixer.volume = value;
        }


        /// <summary>
        /// ���������� ��������� ������.
        /// </summary>
        /// <param name="value">���������</param>
        public void SetMusicVolume(float value)
        {
            _musicMixer.volume = value;
        }

        /// <summary>
        /// ���������� ������ ������.
        /// </summary>
        public void StopMusic()
        {
            _musicMixer.Stop();
        }
    }
}