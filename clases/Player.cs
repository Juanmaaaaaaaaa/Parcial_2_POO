using System;

public class Player
{
    public decimal Gold { get; private set; }
    public PlayerInventory Inventory { get; }

    public Player(decimal gold)
    {
        Gold = gold;
        Inventory = new PlayerInventory();
    }

    public void SpendGold(decimal amount)
    {
        if (amount > Gold)
            throw new InvalidOperationException("No hay suficiente oro");

        Gold -= amount;
    }
}