using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbstractWareHouseView : MonoBehaviour
{
    [SerializeField]
    protected Slider storageContent;

    protected virtual void Start()
    {
        ChangeView();
    }
    protected abstract void ChangeView();
    
}
