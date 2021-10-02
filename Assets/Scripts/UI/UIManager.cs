using UnityEngine;

namespace Game.UI
{

    public class UIManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject _menuScreen;

        [SerializeField]
        private GameObject _gameScreen;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            MenuManager.OnStartGameEvent += GameStarted;
        }

        private void OnDisable()
        {
            MenuManager.OnStartGameEvent -= GameStarted;
        }

        private void GameStarted()
        {
            _menuScreen.SetActive(false);
            _gameScreen.SetActive(true);
        }

        public void MenuOpened()
        {
            _menuScreen.SetActive(true);
            _gameScreen.SetActive(false);
        }
    }
}