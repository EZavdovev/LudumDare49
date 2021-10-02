using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    private Item itemCanGive;

    private bool isDragged = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item;
        collision.TryGetComponent<Item>(out item);
        if (item != null && isDragged == false)
        {
            itemCanGive = item;
            isDragged = true;
            item.transform.parent = playerPos;
            OnDragged();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Item item;
        collision.TryGetComponent<Item>(out item);
        if (itemCanGive == item && itemCanGive != null && isDragged == true)
        {
            itemCanGive = null;
            isDragged = false;
        }
    }
}
