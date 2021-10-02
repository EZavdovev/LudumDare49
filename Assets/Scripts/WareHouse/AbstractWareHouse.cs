using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWareHouse : MonoBehaviour
{
    public static event Action OnDieEvent = delegate { };
    public static event Action OnMoreResourceEvent = delegate { };

    [SerializeField]
    protected string nameResource;
    [SerializeField]
    protected int maxCountResources = 100;
    [SerializeField]
    protected int currentCountResources = 50;
    [SerializeField]
    protected float timeToSpent = 5;
    [SerializeField]
    protected int countLessResources = 1;

    protected float timer;

    protected virtual void Awake()
    {
        timer = 0;
    }

    protected virtual void Update()
    {
        LessResource();
    }
    protected virtual void LessResource()
    {
        timer += Time.deltaTime;
        if(timer < timeToSpent)
        {
            return;
        }
        timer = 0;
        currentCountResources -= countLessResources;
        if(currentCountResources <= 0)
        {
            OnDieEvent();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Item item;
        collision.TryGetComponent<Item>(out item);
        if(item != null && item.NameItem == nameResource)
        {
            UpResource(item);
            Destroy(item.gameObject);
        }
    }
    protected virtual void UpResource(Item item)
    {
        currentCountResources += item.CountItemScore;
        Debug.Log(currentCountResources);
        if(currentCountResources > maxCountResources)
        {
            currentCountResources = maxCountResources;
            OnMoreResourceEvent();
        }
    }

}
