using UnityEngine;
using TMPro;
using Game.Managers;

namespace Game.UI
{

    public class SetDistanceText : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI _distanceText;

        [SerializeField]
        private ShipManager _shipManager;

        private void Update()
        {
            _distanceText.text = Mathf.RoundToInt(_shipManager.DistanceToEarth).ToString();
        }
    }
}