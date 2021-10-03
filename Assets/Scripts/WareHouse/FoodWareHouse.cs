using System;
public class FoodWareHouse : AbstractWareHouse
{
    public static event Action OnFoodChange = delegate { };
    protected override void LessResource()
    {
        base.LessResource();
        OnFoodChange();
    }

    protected override void UpResource(Item item)
    {
        base.UpResource(item);
        OnFoodChange();
    }
}
