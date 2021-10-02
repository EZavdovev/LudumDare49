using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    private AbstractItem itemGenerator;

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

        AbstractItem item = Instantiate(itemGenerator,transform.position, Quaternion.identity);
        item.gameObject.name = item.nameItem;
        isGenerated = true;
        timer = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isGenerated == true && collision.gameObject.name == itemGenerator.nameItem)
        {
            isGenerated = false;
        }
    }
}
