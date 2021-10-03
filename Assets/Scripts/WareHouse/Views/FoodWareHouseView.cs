using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodWareHouseView : AbstractWareHouseView
{
    [SerializeField]
    private FoodWareHouse foodWareHouse;
    private void OnEnable()
    {
        FoodWareHouse.OnFoodChange += ChangeView;
    }
    protected override void ChangeView()
    {
        storageContent.value = (foodWareHouse.CurrentCountResources / foodWareHouse.MaxCountResources);
    }
}
