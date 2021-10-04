using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoseEnergyView : MonoBehaviour
{
    [SerializeField]
    private GameObject _light;

    private void OnEnable()
    {
        AbstractWareHouse.OnNormalizeWorkEvent += OnLight;
        UnStableManager.OnUnStableHappened += OffLight;
    }

    private void OnDisable()
    {
        
    }

    private void OffLight(string name)
    {
        if (name == "Energy")
        {
            _light.SetActive(true);
        }
    }

    private void OnLight(string name)
    {
        if (name == "Energy")
        {
            _light.SetActive(false);
        }
    }
}
