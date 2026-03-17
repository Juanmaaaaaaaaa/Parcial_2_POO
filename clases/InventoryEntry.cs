using System;

public class InventoryEntry
{
    public Item Item { get; }
    public int Quantity { get; private set; }

    public InventoryEntry(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }

    public void Add(int amount)
    {
        Quantity += amount;
    }

    public void Remove(int amount)
    {
        if (amount > Quantity)
            throw new InvalidOperationException("No hay suficiente cantidad");

        Quantity -= amount;
    }
}
