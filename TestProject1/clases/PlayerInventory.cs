using System.Collections.Generic;
using System.Linq;

public class PlayerInventory
{
    private List<InventoryEntry> equipment = new();
    private List<InventoryEntry> supplies = new();

    public void AddItems(List<PurchaseItem> items)
    {
        foreach (var purchase in items)
        {
            if (purchase.Item.Category == ItemCategory.Supply)
                AddToList(supplies, purchase);
            else
                AddToList(equipment, purchase);
        }
    }

    private void AddToList(List<InventoryEntry> list, PurchaseItem purchase)
    {
        var existing = list.FirstOrDefault(e => e.Item == purchase.Item);

        if (existing != null)
            existing.Add(purchase.Quantity);
        else
            list.Add(new InventoryEntry(purchase.Item, purchase.Quantity));
    }
}