using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Game.Audio
{

    public class VolumeSettings : MonoBehaviour
    {

        [SerializeField]
        private AudioSource _musicSource;

        [SerializeField]
        private AudioSource _soundsSource;

        [SerializeField]
        private AudioMixer _mixer;

        [SerializeField]
        private string _volumeParameter = "Master";

        [SerializeField]
        private Slider _volumeSlider;
        private float _multiplier = 30f;

        private void Awake()
        {
            _volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(_volumeParameter, _volumeSlider.value);
        }

        private void Start()
        {
            _volumeSlider.value = PlayerPrefs.GetFloat(_volumeParameter, _volumeSlider.value);
        }

        private void HandleSliderValueChanged(float value)
        {
            _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
        }
    }
}