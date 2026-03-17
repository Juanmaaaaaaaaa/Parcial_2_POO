using System;

public class Accessory : Item
{
    public string Effect { get; }

    public Accessory(string name, decimal price, string effect)
        : base(name, price)
    {
        Effect = effect;
    }

    public override ItemCategory Category => ItemCategory.Accessory;
}