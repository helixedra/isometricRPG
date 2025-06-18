using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InventoryItem
{
    public string name;
    public int amount;
}

public class Inventory
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(string name, int amount)
    {
        InventoryItem item = items.FirstOrDefault(i => i.name == name);

        if (item != null)
        {
            item.amount += amount;
        }
        else
        {
            items.Add(new InventoryItem { name = name, amount = amount });
        }
    }

    public void RemoveItem(string name, int amount)
    {
        InventoryItem item = items.FirstOrDefault(i => i.name == name);

        if (item != null)
        {
            item.amount -= amount;

            if (item.amount <= 0)
            {
                items.Remove(item);
            }
        }
    }

    public bool HasItem(string name, int amount)
    {
        InventoryItem item = items.FirstOrDefault(i => i.name == name);

        if (item != null)
        {
            return item.amount >= amount;
        }

        return false;
    }

    public List<InventoryItem> GetItems()
    {
        return items;
    }
}

public class PlayerData : MonoBehaviour
{

    private int _score;
    private int _health;
    private Inventory _inventory = new Inventory();

    public void SetScore()
    {
        _score++;
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetHealth()
    {
        return _health;
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }

}