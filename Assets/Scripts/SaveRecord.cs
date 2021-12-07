using System.Collections;
using System;
using UnityEngine;
using Game.Managers;

public class SaveRecord : MonoBehaviour
{
    public static event Action<bool,float> OnChangeRecord = delegate { };

    [SerializeField]
    private ShipManager shipManager;

    private float record = 0f;
    private float maxRecord = 0f;

    private bool isNewRecord = false;

    private const string RECORD_KEY = "record_distance";
    private void Start()
    {
        isNewRecord = false;
        maxRecord = shipManager.DistanceToEarth;
        record = PlayerPrefs.GetFloat(RECORD_KEY, 0f);
        ShipManager.OnWinEvent += GetRecord;
        AbstractWareHouse.OnDieEvent += GetRecord;
    }

    private void OnDestroy()
    {
        ShipManager.OnWinEvent -= GetRecord;
        AbstractWareHouse.OnDieEvent -= GetRecord;
    }
    private void GetRecord()
    {
        float currentDistance = shipManager.DistanceToEarth;
        if (record < maxRecord - currentDistance)
        {
            record = maxRecord - currentDistance;
            PlayerPrefs.SetFloat(RECORD_KEY, record);
            PlayerPrefs.Save();
            isNewRecord = true;
        }
        OnChangeRecord(isNewRecord, maxRecord - currentDistance);
    }
}
