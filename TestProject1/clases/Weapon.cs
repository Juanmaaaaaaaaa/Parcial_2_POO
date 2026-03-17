using System;

public class Weapon : Item
{
    public int Damage { get; }

    public Weapon(string name, decimal price, int damage)
        : base(name, price)
    {
        Damage = damage;
    }

    public override ItemCategory Category => ItemCategory.Weapon;
};