using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string nameItem;
    public string NameItem
    {
        get
        {
            return nameItem;
        }
        private set
        {
            nameItem = value;
        }
    }

    public bool IsInGenerator = true;
}
