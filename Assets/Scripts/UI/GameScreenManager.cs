using UnityEngine;
using UnityEngine.UI;
using Game.Managers;

namespace Game.UI
{

    public class GameScreenManager : MonoBehaviour
    {

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
        }

        private void ShowWinPanel()
        {
            _winPanel.SetActive(true);
        }

        public void LoadScene(int index)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}