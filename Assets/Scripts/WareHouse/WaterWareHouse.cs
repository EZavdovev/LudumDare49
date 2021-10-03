using System;
public class WaterWareHouse : AbstractWareHouse
{
    public static event Action OnWaterChange = delegate { };
    protected override void LessResource()
    {
        base.LessResource();
        OnWaterChange();
    }

    protected override void UpResource(Item item)
    {
        base.UpResource(item);
        OnWaterChange();
    }
}
