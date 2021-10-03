using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWareHouseView : AbstractWareHouseView
{
    [SerializeField]
    private EnergyWareHouse energyWareHouse;
    private void OnEnable()
    {
        EnergyWareHouse.OnEnergyChange += ChangeView;
    }
    protected override void ChangeView()
    {
        storageContent.value = (energyWareHouse.CurrentCountResources / energyWareHouse.MaxCountResources);
    }
}
