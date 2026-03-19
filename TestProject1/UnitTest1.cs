using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class UnitTest1
{
    
    private static IEnumerable<TestCaseData> ItemObjects()
    {
        yield return new TestCaseData(new Weapon("Espada", 100, 10))
            .SetName("Crear Weapon válido");

        yield return new TestCaseData(new Armor("Armadura", 200, 20))
            .SetName("Crear Armor válido");

        yield return new TestCaseData(new Accessory("Anillo", 50, "Magia"))
            .SetName("Crear Accessory válido");

        yield return new TestCaseData(new Supply("Poción", 30, 15))
            .SetName("Crear Supply válido");
    }

    [TestCaseSource(nameof(ItemObjects))]
    public void CrearItems(Item item)
    {
        Assert.That(item.Name, Is.Not.Null);
        Assert.That(item.Price, Is.GreaterThan(0));
    }

    
    private static IEnumerable<TestCaseData> StoreObjects()
    {
        yield return new TestCaseData(
            new List<InventoryEntry>
            {
                new InventoryEntry(new Weapon("Espada",100,10), 5)
            })
            .SetName("Store válida con 1 item");

        yield return new TestCaseData(
            new List<InventoryEntry>
            {
                new InventoryEntry(new Supply("Poción",50,20), 10),
                new InventoryEntry(new Armor("Armadura",200,30), 2)
            })
            .SetName("Store válida con múltiples items");
    }

    [TestCaseSource(nameof(StoreObjects))]
    public void CrearStore(List<InventoryEntry> items)
    {
        var store = new Store(items);

        Assert.That(store, Is.Not.Null);
    }

    [Test]
    public void CrearStoreSinItems_Falla()
    {
        Assert.Throws<ArgumentException>(() => new Store(new List<InventoryEntry>()));
    }

    
    private static IEnumerable<TestCaseData> PlayerObjects()
    {
        yield return new TestCaseData(100)
            .SetName("Player con oro válido");

        yield return new TestCaseData(500)
            .SetName("Player con mucho oro");
    }

    [TestCaseSource(nameof(PlayerObjects))]
    public void CrearPlayer(decimal gold)
    {
        var player = new Player(gold);

        Assert.That(player.Gold, Is.EqualTo(gold));
    }

    [Test]
    public void CrearPlayerOroNegativo_Falla()
    {
        Assert.Throws<ArgumentException>(() => new Player(-10));
    }

    
    private static IEnumerable<TestCaseData> CompraExitosa()
    {
        yield return new TestCaseData(500, 100, 2)
            .SetName("Compra exitosa simple");

        yield return new TestCaseData(500, 50, 5)
            .SetName("Compra múltiple suficiente oro");
    }

    [TestCaseSource(nameof(CompraExitosa))]
    public void ComprarItems_Exitosa(decimal gold, decimal price, int quantity)
    {
        var item = new Weapon("Espada", price, 10);

        var store = new Store(new List<InventoryEntry>
        {
            new InventoryEntry(item, 10)
        });

        var player = new Player(gold);

        var result = store.Buy(player, new List<PurchaseItem>
        {
            new PurchaseItem(item, quantity)
        });

        Assert.That(result, Is.True);
        Assert.That(player.Gold, Is.EqualTo(gold - (price * quantity)));
    }

    
    private static IEnumerable<TestCaseData> CompraFallida()
    {
        yield return new TestCaseData(50, 100, 1)
            .SetName("Falla por falta de oro");

        yield return new TestCaseData(1000, 100, 20)
            .SetName("Falla por falta de stock");
    }

    [TestCaseSource(nameof(CompraFallida))]
    public void ComprarItems_Fallida(decimal gold, decimal price, int quantity)
    {
        var item = new Weapon("Espada", price, 10);

        var store = new Store(new List<InventoryEntry>
        {
            new InventoryEntry(item, 5)
        });

        var player = new Player(gold);

        var result = store.Buy(player, new List<PurchaseItem>
        {
            new PurchaseItem(item, quantity)
        });

        Assert.That(result, Is.False);
        Assert.That(player.Gold, Is.EqualTo(gold)); 
    }

    
    private static IEnumerable<TestCaseData> InventarioJugador()
    {
        yield return new TestCaseData(new Supply("Poción", 50, 20))
            .SetName("Item va a consumibles");

        yield return new TestCaseData(new Weapon("Espada", 100, 10))
            .SetName("Item va a equipamiento");
    }

    [TestCaseSource(nameof(InventarioJugador))]
    public void ActualizarInventario(Item item)
    {
        var inventory = new PlayerInventory();

        inventory.AddItems(new List<PurchaseItem>
        {
            new PurchaseItem(item, 1)
        });

        Assert.That(inventory, Is.Not.Null); 
    }
}