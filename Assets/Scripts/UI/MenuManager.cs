using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{

    public class MenuManager : MonoBehaviour
    {

        public static event Action OnStartGameEvent = delegate { };

        [SerializeField]
        private GameObject _mainPanel;

        [SerializeField]
        private GameObject _creditsPanel;

        [SerializeField]
        private GameObject _optionsPanel;

        [SerializeField]
        private Button _creditsButton;

        [SerializeField]
        private Button _optionsButton;

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _exitButton;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
            _optionsButton.onClick.AddListener(OpenOptions);
            _creditsButton.onClick.AddListener(OpenCredits);
        }

        private void OpenOptions()
        {
            _mainPanel.SetActive(false);
            _creditsPanel.SetActive(false);
            _optionsPanel.SetActive(true);
        }

        private void OpenCredits()
        {
            _mainPanel.SetActive(false);
            _optionsPanel.SetActive(false);
            _creditsPanel.SetActive(true);
        }

        public void OpenMainPanel()
        {
            _optionsPanel.SetActive(false);
            _creditsPanel.SetActive(false);
            _mainPanel.SetActive(true);
        }

        private void StartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            OnStartGameEvent();
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}