using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{

    public static event Action OnTakeItem = delegate { };

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
        }
    }

    private void Update()
    {
        if (itemCanGive != null && Input.GetKeyDown(KeyCode.E))
        {
            isDragged = true;
            itemCanGive.transform.parent = playerPos;
            itemCanGive.transform.position = playerPos.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Item item;
        collision.TryGetComponent<Item>(out item);
        if (itemCanGive != null && itemCanGive == item)
        {
            itemCanGive = null;
            isDragged = false;
        }
    }
}
