using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnStableManagerView : MonoBehaviour
{
    [SerializeField]
    private Text Title;

    [SerializeField]
    private List<Text> wareHouseNames = new List<Text>();

    private void OnEnable()
    {
        UnStableManager.OnUnStableHappened += OpenWarningName;
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
        
    }
}
