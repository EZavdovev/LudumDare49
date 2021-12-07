using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{

    public class MenuManager : MonoBehaviour
    {

        public static event Action OnStartGameEvent = delegate { };
        public static event Action OnMenuButtonPressed = delegate { };
        public static event Action OnMenuActive = delegate { };

        [SerializeField]
        private GameObject _mainPanel;

        [SerializeField]
        private GameObject _creditsPanel;

        [SerializeField]
        private GameObject _optionsPanel;

        [SerializeField]
        private GameObject _tutorialPanel;

        [SerializeField]
        private GameObject _leaderBoardPanel;

        [SerializeField]
        private Button _creditsButton;

        [SerializeField]
        private Button _optionsButton;

        [SerializeField]
        private Button _startButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private Button _tutorialButton;

        [SerializeField]
        private Button _leaderBoardButton;

        private void OnEnable()
        {
            OnMenuActive();
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
            _optionsButton.onClick.AddListener(OpenOptions);
            _creditsButton.onClick.AddListener(OpenCredits);
            _startButton.onClick.AddListener(PlaySound);
            _exitButton.onClick.AddListener(PlaySound);
            _optionsButton.onClick.AddListener(PlaySound);
            _creditsButton.onClick.AddListener(PlaySound);
            _tutorialButton.onClick.AddListener(PlaySound);
            _tutorialButton.onClick.AddListener(Tutorial);
            _leaderBoardButton.onClick.AddListener(PlaySound);
            _leaderBoardButton.onClick.AddListener(LeaderBoard);
        }

        private void Tutorial()
        {
            _leaderBoardPanel.SetActive(false);
            _mainPanel.SetActive(false);
            _creditsPanel.SetActive(false);
            _optionsPanel.SetActive(false);
            _tutorialPanel.SetActive(true);
        }

        private void OpenOptions()
        {
            _leaderBoardPanel.SetActive(false);
            _mainPanel.SetActive(false);
            _creditsPanel.SetActive(false);
            _tutorialPanel.SetActive(false);
            _optionsPanel.SetActive(true);
        }

        private void OpenCredits()
        {
            _leaderBoardPanel.SetActive(false);
            _mainPanel.SetActive(false);
            _optionsPanel.SetActive(false);
            _tutorialPanel.SetActive(false);
            _creditsPanel.SetActive(true);
        }

        public void OpenMainPanel()
        {
            _leaderBoardPanel.SetActive(false);
            _optionsPanel.SetActive(false);
            _creditsPanel.SetActive(false);
            _tutorialPanel.SetActive(false);
            _mainPanel.SetActive(true);
            PlaySound();
            _tutorialPanel.GetComponent<TutorialPanel>()._currentSlide = 0;
        }

        public void LeaderBoard()
        {
            _leaderBoardPanel.SetActive(true);
            _optionsPanel.SetActive(false);
            _creditsPanel.SetActive(false);
            _tutorialPanel.SetActive(false);
            _mainPanel.SetActive(false);
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

        private void PlaySound()
        {
            OnMenuButtonPressed();
        }
    }
}