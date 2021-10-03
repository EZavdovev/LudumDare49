using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelWareHouseView : AbstractWareHouseView
{
    [SerializeField]
    private FuelWareHouse fuelWareHouse;
    private void OnEnable()
    {
        FuelWareHouse.OnFuelChange += ChangeView;
    }
    protected override void ChangeView()
    {
        storageContent.value = (fuelWareHouse.CurrentCountResources / fuelWareHouse.MaxCountResources);
    }
}
