using UnityEngine;

namespace Game.UI
{

    public class TutorialPanel : MonoBehaviour
    {

        [SerializeField]
        private int _currentSlide = 0;

        [SerializeField]
        private Transform _slidesParent;

        [SerializeField]
        private Transform _buttonNext;

        [SerializeField]
        private Transform _buttonMenu;

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