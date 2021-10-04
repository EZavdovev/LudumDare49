using System;
using UnityEngine;
using Game.UI;

namespace Game.Managers
{

    public class ShipManager : MonoBehaviour
    {

        public static event Action OnWinEvent = delegate { };
        public static event Action OnStopEngines = delegate { };

        [SerializeField]
        private float distanceToEarth = 4000f;

        [SerializeField]
        private float speedShip = 5f;

        public static int NegativeModifier { get; set; }

        private bool isPaused = false;
        public float DistanceToEarth 
        { 
            get 
            {
                return distanceToEarth;
            }
        }

        private void Update()
        {
            if (isPaused)
            {
                return;
            }
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

        private void OnEnable()
        {
            NegativeModifier = 0;
            GameScreenManager.OnStopGame += PauseManager;
        }

        private void OnDisable()
        {
            GameScreenManager.OnStopGame -= PauseManager;
        }

        private void PauseManager()
        {
            isPaused = true;
        }
    }
}