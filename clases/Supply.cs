using System;

public class Supply : Item
{
    public int EffectValue { get; }

    public Supply(string name, decimal price, int effectValue)
        : base(name, price)
    {
        EffectValue = effectValue;
    }

    public override ItemCategory Category => ItemCategory.Supply;
}