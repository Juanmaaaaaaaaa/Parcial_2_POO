using System;

public class Item
{
    public string Name { get; }
    public decimal Price { get; }
    public ItemCategory Category { get; }

    public Item(string name, decimal price, ItemCategory category)
    {
        if (price <= 0)
            throw new ArgumentException("El precio debe ser positivo");

        Name = name;
        Price = price;
        Category = category;
    }
}