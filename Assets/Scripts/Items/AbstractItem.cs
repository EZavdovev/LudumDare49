using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractItem : MonoBehaviour
{
    [SerializeField]
    public string nameItem 
    { 
        get;
        private set;
    }
}
