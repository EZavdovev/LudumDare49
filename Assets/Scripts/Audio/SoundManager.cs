using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using Game.UI;
using Game.Managers;

namespace Game.Audio
{

    public class SoundManager : MonoBehaviour
    {

        [SerializeField]
        private AudioSource _musicSource;

        [SerializeField]
        private AudioSource _soundsSource;

        [SerializeField]
        private AudioSource _footStepsSource;

        [SerializeField]
        private AudioSource _engineSource;

        [SerializeField]
        private AudioSource _sirenSource;

        [SerializeField]
        private AudioMixer _mixer;

        [SerializeField]
        private string _musicParameter = "Music";

        [SerializeField]
        private string _soundsParameter = "Sounds";

        [SerializeField]
        private Slider _musicSlider;

        [SerializeField]
        private Slider _soundsSlider;

        [SerializeField]
        private List<AudioClip> _sounds = new List<AudioClip>();

        [SerializeField]
        private List<AudioClip> _music = new List<AudioClip>();

        private float _multiplier = 30f;

        private void Awake()
        {
            _musicSlider.onValueChanged.AddListener(HandleMusicSlider);
            _soundsSlider.onValueChanged.AddListener(HandleSoundsSlider);
        }

        private void OnEnable()
        {
            MenuManager.OnMenuButtonPressed += PlayMenuSound;
            MenuManager.OnStartGameEvent += StartPlayingEngines;
            MenuManager.OnStartGameEvent += PlayGamePlayMusic;
            MenuManager.OnMenuActive += PlayMenuMusic;
            PlayerMove.OnPlayFootstepsEvent += PlayRunningSound;
            PlayerMove.OnStopPlatingFootstepsEvent += StopPlayingRunningSound;
            ShipManager.OnStopEngines += StopPlayingEngines;
            ShipManager.OnWinEvent += PlayWinSound;
            DragItem.OnTakeItem += PlayPickupSound;
            AbstractWareHouse.OnMoreResourceEvent += PlayUpResourceSound;
            AbstractWareHouse.OnDieEvent += PlayLoseSound;
            UnStableManager.OnUnStableStarted += PlaySiren;
            UnStableManager.OnStableWork += StopSiren;
        }

        private void OnDisable()
        {
            MenuManager.OnMenuButtonPressed -= PlayMenuSound;
            MenuManager.OnStartGameEvent -= StartPlayingEngines;
            MenuManager.OnMenuActive -= PlayMenuMusic;
            MenuManager.OnStartGameEvent -= PlayGamePlayMusic;
            PlayerMove.OnPlayFootstepsEvent -= PlayRunningSound;
            PlayerMove.OnStopPlatingFootstepsEvent -= StopPlayingRunningSound;
            PlayerPrefs.SetFloat(_musicParameter, _musicSlider.value);
            ShipManager.OnStopEngines -= StopPlayingEngines;
            ShipManager.OnWinEvent -= PlayWinSound;
            DragItem.OnTakeItem -= PlayPickupSound;
            AbstractWareHouse.OnMoreResourceEvent -= PlayUpResourceSound;
            AbstractWareHouse.OnDieEvent -= PlayLoseSound;
            UnStableManager.OnUnStableStarted -= PlaySiren;
            UnStableManager.OnStableWork -= StopSiren;
        }

        private void Start()
        {
            _musicSlider.value = PlayerPrefs.GetFloat(_musicParameter, _musicSlider.value);
        }

        private void HandleMusicSlider(float value)
        {
            _mixer.SetFloat(_musicParameter, Mathf.Log10(value) * _multiplier);
        }

        private void HandleSoundsSlider(float value)
        {
            _mixer.SetFloat(_soundsParameter, Mathf.Log10(value) * _multiplier);
        }

        private void PlayMenuSound()
        {
            _soundsSource.PlayOneShot(_sounds[0]);
        }

        private void PlayMenuMusic()
        {
            _musicSource.clip = _music[0];
            _musicSource.Play();
        }

        private void PlayGamePlayMusic()
        {
            _musicSource.clip = _music[1];
            _musicSource.Play();
        }

        private void PlayRunningSound()
        {
            if (_footStepsSource.isPlaying) 
            {
                return;
            }
            _footStepsSource.PlayOneShot(_sounds[1]);
        }

        private void StopPlayingRunningSound()
        {
            _footStepsSource.Stop();
        }

        private void StartPlayingEngines()
        {
            _engineSource.Play();
            _engineSource.loop = true;
        }

        private void StopPlayingEngines()
        {
            _engineSource.PlayOneShot(_sounds[3]);
            _engineSource.loop = false;
        }

        private void PlayPickupSound()
        {
            _soundsSource.PlayOneShot(_sounds[4]);
        }

        private void PlayUpResourceSound()
        {
            _soundsSource.PlayOneShot(_sounds[5]);
        }

        private void PlaySiren()
        {
            if(_sirenSource.isPlaying == true)
            {
                return;
            }
            _sirenSource.Play();
        }

        private void StopSiren()
        {
            _sirenSource.Stop();
        }

        private void PlayWinSound()
        {
            _soundsSource.PlayOneShot(_sounds[6]);
        }

        private void PlayLoseSound()
        {
            _soundsSource.PlayOneShot(_sounds[7]);
        }
    }
}