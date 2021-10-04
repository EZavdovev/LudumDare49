using System;
using UnityEngine;
using Game.UI;

namespace Game.Managers
{

    public class ShipManager : MonoBehaviour
    {

        public static event Action OnWinEvent = delegate { };
        public static event Action OnStopEngines = delegate { };
        public static event Action OnStartEngines = delegate { };

        [SerializeField]
        private float distanceToEarth = 4000f;

        [SerializeField]
        private float speedShip = 5f;

        public static int NegativeModifier { get; set; }

        private bool isPaused = false;

        private bool isEngineOut = false;
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
            if(speedShip + NegativeModifier <= 0f && isEngineOut == false)
            {
                isEngineOut = true;
                OnStopEngines();
            }

            if(speedShip + NegativeModifier > 0f && isEngineOut == true)
            {
                isEngineOut = false;
                OnStartEngines();
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