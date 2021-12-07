using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveRecordList : MonoBehaviour
{
    [Serializable]
    private class SavedDataWrapper
    {
        public List<float> savedDatas;
    }

    [SerializeField]
    private int listLimit = 5;

    private static List<float> savedDatas;
    public static List<float> SavedDatas => savedDatas;

    private const string RECORDS_KEY = "ListRecord";

    private void Awake()
    {
        savedDatas = new List<float>();
        LoadFromPlayerPrefs();
        SaveRecord.OnChangeRecord += SaveRecordInList;
    }

    private void OnDestroy()
    {
        SaveRecord.OnChangeRecord -= SaveRecordInList;
    }

    private void SaveRecordInList(bool isNewRecord, float newRecord)
    {
        InsertNewRecord(newRecord);
        CheckTail();
        SaveToPlayerPrefs();
    }

    private void InsertNewRecord(float newRecord)
    {
        for (int i = savedDatas.Count - 1; i >= 0; i--)
        {
            if (savedDatas[i] >= newRecord)
            {
                savedDatas.Insert(i + 1, newRecord);
                return;
            }
        }
        savedDatas.Insert(0, newRecord);
    }

    private void CheckTail()
    {
        while (savedDatas.Count > listLimit)
        {
            savedDatas.Remove(savedDatas[savedDatas.Count - 1]);
        }
    }

    private SavedDataWrapper GetWrapper()
    {
        return (new SavedDataWrapper
        {
            savedDatas = savedDatas
        });
    }
    private void LoadFromPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey(RECORDS_KEY))
        {
            return;
        }
        var wrapper = JsonUtility.FromJson<SavedDataWrapper>(PlayerPrefs.GetString(RECORDS_KEY));
        savedDatas = wrapper.savedDatas;
    }

    private void SaveToPlayerPrefs()
    {
        var wrapper = GetWrapper();
        var json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString(RECORDS_KEY, json);
    }
}

