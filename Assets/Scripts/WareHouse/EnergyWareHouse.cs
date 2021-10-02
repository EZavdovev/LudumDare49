using System;
public class EnergyWareHouse : AbstractWareHouse
{
    public static event Action OnEnergyChange = delegate { };
    protected override void LessResource()
    {
        base.LessResource();
        OnEnergyChange();
    }

    protected override void UpResource(Item item)
    {
        base.UpResource(item);
        OnEnergyChange();
    }
}
