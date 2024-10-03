using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class InventoryStaticClass
{
    private static Dictionary<PseudoItemId, List<Item>> inv = new Dictionary<PseudoItemId, List<Item>>();
    public static Dictionary<PseudoItemId, List<Item>> invChest = new Dictionary<PseudoItemId, List<Item>>();
    public static Dictionary<PseudoItemId, List<Item>> GetInventory()
    {
        return inv;
    }

    public static List<Item> GetItem(PseudoItemId id)
    {
        if (!inv.Keys.Contains(id)) inv.Add(id, new List<Item>());

        return inv[id];
    }
    public static List<Item> GetItemBothInvs(PseudoItemId id)
    {
        List<Item> list = new List<Item>();
        if (inv.Keys.Contains(id))
        {
            foreach(Item i in inv[id])
            {
                list.Add(i);    
            }
        }
        if (invChest.Keys.Contains(id))
        {
            foreach (Item i in invChest[id])
            {
                list.Add(i);
            }
        }
        return list;
    }
    public static void AddItem(Item item)
    {
        if (!inv.Keys.Contains(item.itemId)) inv.Add(item.itemId, new List<Item>());
        inv[item.itemId].Add(item);
    }

    public static void AddItems(List<Item> items)
    {
        if(items.Count== 0) return;
        if (!inv.Keys.Contains(items[0].itemId)) inv.Add(items[0].itemId, new List<Item>());

        foreach (Item item in items)
        {
            inv[item.itemId].Add(item);
        }
    }

    public static void AddItems(Item[] items)
    {
        if (!inv.Keys.Contains(items[0].itemId)) inv.Add(items[0].itemId, new List<Item>());

        foreach (Item item in items)
        {
            inv[item.itemId].Add(item);
        }
    }

    public static void RemoveItem(Item item)
    {
        if (!inv.Keys.Contains(item.itemId)) inv.Add(item.itemId, new List<Item>());

        inv[item.itemId].Remove(item);  
    }
}
