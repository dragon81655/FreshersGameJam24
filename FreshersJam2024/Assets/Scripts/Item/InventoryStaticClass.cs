using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryStaticClass
{
    private static Dictionary<PseudoItemId, List<Item>> inv = new Dictionary<PseudoItemId, List<Item>>();
    public static Dictionary<PseudoItemId, List<Item>> GetInventory()
    {
        return inv;
    }

    public static List<Item> GetItem(PseudoItemId id)
    {
        return inv[id];
    }

    public static void AddItem(Item item)
    {
        inv[item.itemId].Add(item);
    }

    public static void AddItems(List<Item> items)
    {
        foreach (Item item in items)
        {
            inv[item.itemId].Add(item);
        }
    }

    public static void AddItems(Item[] items)
    {
        foreach (Item item in items)
        {
            inv[item.itemId].Add(item);
        }
    }
}
