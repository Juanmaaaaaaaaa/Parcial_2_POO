using System;

public class Armor : Item
{
    public int Defense { get; }

    public Armor(string name, decimal price, int defense)
        : base(name, price)
    {
        Defense = defense;
    }

    public override ItemCategory Category => ItemCategory.Armor;
}