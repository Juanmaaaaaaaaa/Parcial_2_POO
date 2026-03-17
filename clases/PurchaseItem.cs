using System;

public class PurchaseItem
{
    public Item Item { get; }
    public int Quantity { get; }

    public PurchaseItem(Item item, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Cantidad inválida");

        Item = item;
        Quantity = quantity;
    }
}