using System;
using System.Collections.Generic;
using System.Linq;

public class Store
{
    private List<InventoryEntry> inventory;

    public Store(List<InventoryEntry> initialItems)
    {
        if (initialItems == null || initialItems.Count == 0)
            throw new ArgumentException("La tienda debe tener al menos un item");

        inventory = initialItems;
    }

    public void AddItem(Item item, int quantity)
    {
        var existing = inventory.FirstOrDefault(e =>
            e.Item.Name == item.Name &&
            e.Item.Category == item.Category);

        if (existing != null)
        {
            if (existing.Item.Price != item.Price)
                throw new InvalidOperationException("No se permiten precios distintos para el mismo item");

            existing.Add(quantity);
        }
        else
        {
            inventory.Add(new InventoryEntry(item, quantity));
        }
    }

    public bool Buy(Player player, List<PurchaseItem> itemsToBuy)
    {
        decimal total = 0;

        
        foreach (var purchase in itemsToBuy)
        {
            var entry = inventory.FirstOrDefault(e => e.Item == purchase.Item);

            if (entry == null || entry.Quantity < purchase.Quantity)
                return false;

            total += purchase.Item.Price * purchase.Quantity;
        }

        
        if (player.Gold < total)
            return false;

        
        foreach (var purchase in itemsToBuy)
        {
            var entry = inventory.First(e => e.Item == purchase.Item);
            entry.Remove(purchase.Quantity);
        }

        player.SpendGold(total);
        player.Inventory.AddItems(itemsToBuy);

        return true;
    }
}