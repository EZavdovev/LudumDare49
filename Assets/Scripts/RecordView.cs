using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordView : MonoBehaviour
{
    [SerializeField]
    private Text newRecord;
    [SerializeField]
    private Text Record;
    
    private void OnEnable()
    {
        SaveRecord.OnChangeRecord += ChangeView;
    }

    private void ChangeView(bool isNewRecord, float record)
    {
        if (newRecord != null)
        {
            newRecord.gameObject.SetActive(isNewRecord);
        }
        Record.text = "Distance: " + (int)record;
    }
    private void OnDisable()
    {
        SaveRecord.OnChangeRecord -= ChangeView;
    }
}
