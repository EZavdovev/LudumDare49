using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private Item itemGenerator;

    private Item itemWasGenerate;

    [SerializeField]
    private float timeToGenerate;

    private float timer;

    private bool isGenerated;

    private void Awake()
    {
        timer = 0;
        isGenerated = false;
    }

    private void Update()
    {
        Generate();
    }

    private void Generate() 
    { 
        if(isGenerated == true)
        {
            return;
        }

        if(timer < timeToGenerate)
        {
            timer += Time.deltaTime;
            return;
        }

        Item item = Instantiate(itemGenerator,transform.position, Quaternion.identity);
        item.gameObject.name = item.NameItem;
        itemWasGenerate = item;
        isGenerated = true;
        timer = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Item item;
        collision.TryGetComponent<Item>(out item);
        if (itemWasGenerate != null && item != null && item.NameItem == itemWasGenerate.NameItem && item.IsInGenerator == true)
        {
            itemWasGenerate.IsInGenerator = false;
            isGenerated = false;
            itemWasGenerate = null;
        }
    }


}
