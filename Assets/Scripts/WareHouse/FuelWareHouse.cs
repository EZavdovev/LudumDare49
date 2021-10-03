using System;
public class FuelWareHouse : AbstractWareHouse
{
    public static event Action OnFuelChange = delegate { };
    protected override void LessResource()
    {
        base.LessResource();
        OnFuelChange();
    }

    protected override void UpResource(Item item)
    {
        base.UpResource(item);
        OnFuelChange();
    }
}
