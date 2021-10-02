using System;
using UnityEngine;

namespace Game.Managers
{

    public class ShipManager : MonoBehaviour
    {

        public static event Action OnWinEvent = delegate { };

        [SerializeField]
        private float distanceToEarth = 10000f;

        [SerializeField]
        private float speedShip = 5f;

        public int NegativeModifier { get; set; }

        public float DistanceToEarth { get; }

        private void Update()
        {
            distanceToEarth -= (speedShip + NegativeModifier) * Time.deltaTime;
            if(distanceToEarth <= 0f)
            {
                OnWinEvent();
            }
        }
    }
}