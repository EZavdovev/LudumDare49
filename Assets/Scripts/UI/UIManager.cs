using UnityEngine;

namespace Game.UI
{

    public class UIManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject _menuScreen;

        [SerializeField]
        private GameObject _gameScreen;

        private static UIManager Instance;

        private void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(this);
            MenuManager.OnStartGameEvent += GameStarted;
            Instance = this;
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