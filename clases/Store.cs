using System;

public class Store
{
    private List<InventoryEntry> inventory = new List<InventoryEntry>();

    public Store(List<InventoryEntry> initialItems)
    {
        if (initialItems == null || initialItems.Count == 0)
            throw new ArgumentException("La tienda debe iniciar con al menos un item");

        inventory = initialItems;
    }

    public void AddItem(Item item, int quantity)
    {
        var existing = inventory.FirstOrDefault(e =>
            e.Item.Name == item.Name &&
            e.Item.Category == item.Category);

        if (existing != null)
        {
            // Validar precio consistente
            if (existing.Item.Price != item.Price)
                throw new InvalidOperationException("No se permiten precios distintos para el mismo item");

            existing.Add(quantity);
        }
        else
        {
            inventory.Add(new InventoryEntry(item, quantity));
        }
    }

}

