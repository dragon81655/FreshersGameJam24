using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="LootTable")]
public class LootTableBase : ScriptableObject
{
    //Just had this to a list of loot tables based on accepted tools;
    [Header("Basic info")]
    [TextArea(3, 20)]
    public string description;
    public List<AcceptedTools> toolTypes;
    public int chance;

    [Header("Rolls")]
    public List<ItemLootTable> itemLootTables;
    public UnityEvent onRoll;

    public ItemLootTable RollTable()
    {
        if (itemLootTables.Count != 0)
        {
            int totalChance = 0;
            foreach (ItemLootTable i in itemLootTables)
            {
                totalChance += i.chance;
            }
            float value = totalChance * UnityEngine.Random.Range(0f, 1f);
            foreach (ItemLootTable i in itemLootTables)
            {
                value -= i.chance;
                if (value <= 0)
                {
                    return i;
                }
            }
        }
        return new ItemLootTable();
        
    }
}



