using UnityEngine;
using UnityEngine.UI;

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
        }

        private void OnDisable()
        {
            AbstractWareHouse.OnDieEvent -= ShowLosePanel;
        }

        private void ShowLosePanel()
        {
            _winPanel.SetActive(true);
        }

        private void ShowWinPanel()
        {
            _losePanel.SetActive(true);
        }

        public void LoadScene(int index)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}