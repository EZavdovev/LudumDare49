using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UnStableManagerView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Title;

    [SerializeField]
    private List<TextMeshProUGUI> wareHouseNames = new List<TextMeshProUGUI>();

    private void OnEnable()
    {
        UnStableManager.OnUnStableHappened += OpenWarningName;
        UnStableManager.OnUnStableStarted += OpenTitle;
        UnStableManager.OnStableWork += CloseTitle;
        AbstractWareHouse.OnNormalizeWorkEvent += CloseWarningName;

    }

    private void OpenWarningName(string name)
    {
        for(int i = 0; i < wareHouseNames.Count; i++)
        {
            if(name == wareHouseNames[i].text)
            {
                wareHouseNames[i].gameObject.SetActive(true);
            }
        }
    }

    private void CloseWarningName(string name)
    {
        for (int i = 0; i < wareHouseNames.Count; i++)
        {
            if (name == wareHouseNames[i].text)
            {
                wareHouseNames[i].gameObject.SetActive(false);
            }
        }
    }

    private void OpenTitle()
    {
        Title.gameObject.SetActive(true);
    }

    private void CloseTitle()
    {
        Title.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        UnStableManager.OnUnStableHappened -= OpenWarningName;
        UnStableManager.OnUnStableStarted -= OpenTitle;
        UnStableManager.OnStableWork -= CloseTitle;
        AbstractWareHouse.OnNormalizeWorkEvent -= CloseWarningName;
    }
}
