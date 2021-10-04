using UnityEngine;
using UnityEngine.UI;
using Game.Managers;
using System;

namespace Game.UI
{

    public class GameScreenManager : MonoBehaviour
    {
        public static event Action OnStopGame = delegate { };
        [SerializeField]
        private GameObject _losePanel;

        [SerializeField]
        private GameObject _winPanel;

        [SerializeField]
        private Button _tryAgainButton;

        private void OnEnable()
        {
            AbstractWareHouse.OnDieEvent += ShowLosePanel;
            ShipManager.OnWinEvent += ShowWinPanel;
        }

        private void OnDisable()
        {
            AbstractWareHouse.OnDieEvent -= ShowLosePanel;
            ShipManager.OnWinEvent -= ShowWinPanel;
        }

        private void ShowLosePanel()
        {
            _losePanel.SetActive(true);
            OnStopGame();
        }

        private void ShowWinPanel()
        {
            _winPanel.SetActive(true);
            OnStopGame();
        }

        public void LoadScene(int index)
        {
            _losePanel.SetActive(false);
            _winPanel.SetActive(false);
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}