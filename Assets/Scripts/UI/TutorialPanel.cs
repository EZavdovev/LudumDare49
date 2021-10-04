using UnityEngine;

namespace Game.UI
{

    public class TutorialPanel : MonoBehaviour
    {

        public int _currentSlide = 0;

        [SerializeField]
        private Transform _slidesParent;

        [SerializeField]
        private Transform _buttonNext;

        [SerializeField]
        private Transform _buttonMenu;

        private void OnEnable()
        {
            _currentSlide = 0;
            _slidesParent.GetChild(_currentSlide).gameObject.SetActive(true);
            for (int i = 1; i < 6; i++)
            {
                _slidesParent.GetChild(i).gameObject.SetActive(false);
            }
            _buttonNext.gameObject.SetActive(true);
            _buttonMenu.gameObject.SetActive(false);
        }

        public void ShowNextSlide()
        {
            _currentSlide++;
            _slidesParent.GetChild(_currentSlide).transform.gameObject.SetActive(true);
            if(_currentSlide == 5)
            {
                _buttonNext.gameObject.SetActive(false);
                _buttonMenu.gameObject.SetActive(true);
            }
        }
    }
}