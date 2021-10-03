using System;
using UnityEngine;

namespace Game.Managers
{

    public class ShipManager : MonoBehaviour
    {

        public static event Action OnWinEvent = delegate { };
        public static event Action OnStopEngines = delegate { };

        [SerializeField]
        private float distanceToEarth = 10000f;

        [SerializeField]
        private float speedShip = 5f;

        public static int NegativeModifier { get; set; }

        public float DistanceToEarth 
        { 
            get 
            {
                return distanceToEarth;
            }
        }

        private void Update()
        {
            distanceToEarth -= (speedShip + NegativeModifier) * Time.deltaTime;
            if(speedShip + NegativeModifier <= 0f)
            {
                OnStopEngines();
            }
            if(distanceToEarth <= 0f)
            {
                OnWinEvent();
            }
        }
    }
}