using Game.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnStableManager : MonoBehaviour
{
    public static event Action<string> OnUnStableHappened = delegate { };

    public static event Action OnUnStableStarted = delegate { };
    public static event Action OnStableWork = delegate { };

    [SerializeField]
    private List<string> NameResourceWareHouses = new List<string>();

    private List<bool> statesResourceWareHouses = new List<bool>();

    private int countDanger;

    [SerializeField]
    private float minTimerToGenerate;
    [SerializeField]
    private float maxTimerToGenerate;

    private float timeToGenerate;

    private float timer;

    private bool isPaused = false;

    private void Awake()
    {
        timer = 0;
        countDanger = 0;
        for(int i = 0; i < NameResourceWareHouses.Count; i++)
        {
            statesResourceWareHouses.Add(false);
        }
        timeToGenerate = UnityEngine.Random.Range(minTimerToGenerate, maxTimerToGenerate);
    }

    private void OnEnable()
    {
        EnergyWareHouse.OnNormalizeWorkEvent += StableWareHouse;
        GameScreenManager.OnStopGame += PauseManager;
    }

    private void OnDisable()
    {
        EnergyWareHouse.OnNormalizeWorkEvent -= StableWareHouse;
        GameScreenManager.OnStopGame -= PauseManager;
    }

    private void Update()
    {
        if (isPaused)
        {
            return;
        }
        UnStableGenerate();
    }

    private void UnStableGenerate()
    {
        timer += Time.deltaTime;
        if(timer < timeToGenerate)
        {
            return;
        }
        timer = 0;
        timeToGenerate = UnityEngine.Random.Range(minTimerToGenerate, maxTimerToGenerate);
        int idWareHouse = UnityEngine.Random.Range(0, statesResourceWareHouses.Count);

        if(statesResourceWareHouses[idWareHouse] == false)
        {
            statesResourceWareHouses[idWareHouse] = true;
            OnUnStableHappened(NameResourceWareHouses[idWareHouse]);
            if(countDanger == 0)
            {
                OnUnStableStarted();
            }
            countDanger++;
        }
    }

    private void StableWareHouse(string nameWareHouseNormalized)
    {
        for(int i = 0; i < NameResourceWareHouses.Count; i++)
        {
            if(nameWareHouseNormalized == NameResourceWareHouses[i])
            {
                statesResourceWareHouses[i] = false;
                countDanger--;
                if(countDanger == 0)
                {
                    OnStableWork();
                }
            }
        }
    }


    private void PauseManager()
    {
        isPaused = true;
    }

}
