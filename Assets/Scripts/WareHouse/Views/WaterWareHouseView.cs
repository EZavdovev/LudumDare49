using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWareHouseView : AbstractWareHouseView
{
    [SerializeField]
    private WaterWareHouse waterWareHouse;
    private void OnEnable()
    {
        WaterWareHouse.OnWaterChange += ChangeView;
    }
    protected override void ChangeView()
    {
        storageContent.value = ((float)waterWareHouse.CurrentCountResources / (float)waterWareHouse.MaxCountResources);
    }
}
