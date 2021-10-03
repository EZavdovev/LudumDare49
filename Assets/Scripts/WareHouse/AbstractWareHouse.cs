using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Managers;
public abstract class AbstractWareHouse : MonoBehaviour
{
    public static event Action OnDieEvent = delegate { };
    public static event Action OnMoreResourceEvent = delegate { };
    public static event Action<string> OnNormalizeWorkEvent = delegate { };

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
    [SerializeField]
    protected int negativeModifier = 2;

    [SerializeField]
    protected Transform PlayerPos;

    [SerializeField]
    protected float distPlayerToWareHouseNeed = 2;

    protected float timer;
    protected bool isNeedRepair = false;

    protected virtual void Awake()
    {
        timer = 0;
    }

    protected virtual void OnEnable()
    {
        UnStableManager.OnUnStableHappened += DangerHappened;
    }

    protected virtual void OnDisable()
    {
        UnStableManager.OnUnStableHappened -= DangerHappened;
    }

    protected virtual void Update()
    {
        DangerNormalized();
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
        if(currentCountResources > maxCountResources)
        {
            currentCountResources = maxCountResources;
            OnMoreResourceEvent();
        }
    }

    protected virtual void DangerHappened(string name)
    {
        if(name == nameResource)
        {
            ShipManager.NegativeModifier -= negativeModifier;
            timeToSpent -= negativeModifier;
            isNeedRepair = true;
        }
    }

    protected virtual void DangerNormalized()
    {
        double dist = Math.Sqrt(PlayerPos.position.x * PlayerPos.position.x + PlayerPos.position.y * PlayerPos.position.y);
        dist -= Math.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        if(dist < 0)
        {
            dist = -dist;
        }
        if (dist < distPlayerToWareHouseNeed && Input.GetKeyDown(KeyCode.Q) && isNeedRepair == true)
        {
            isNeedRepair = false;
            timeToSpent += negativeModifier;
            ShipManager.NegativeModifier += negativeModifier;
            OnNormalizeWorkEvent(nameResource);
        }
    }
}
