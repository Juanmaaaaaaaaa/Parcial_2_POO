using System;

public abstract class Item
{
    public string Name { get; }
    public decimal Price { get; }

    protected Item(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre no puede estar vacío");

        if (price <= 0)
            throw new ArgumentException("El precio debe ser positivo");

        Name = name;
        Price = price;
    }

    public abstract ItemCategory Category { get; }
}