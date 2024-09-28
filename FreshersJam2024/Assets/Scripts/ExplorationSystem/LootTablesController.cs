using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Properties;
using UnityEditor;
using UnityEngine;

public class LootTablesController : MonoBehaviour
{
    [SerializeField]
    private List<LootTableBase> lootTableBases;
    private List<List<LootTableBase>> lootTables = new List<List<LootTableBase>>(); 
    void Start()
    {
        for (int i = 0;i < Enum.GetValues(typeof(AcceptedTools)).Length; i++)
        {
            lootTables.Add(new List<LootTableBase>());
        }
        GetScriptableObjects();
        DebugLootTables();
    }

    private void DebugLootTables()
    {
        for (int i = 0; i < lootTables.Count; i++)
        {
            foreach (LootTableBase l in lootTables[i])
            {
                Debug.Log("Table: " + i + "\nName: " + l.name);
            }
        }
    }

    private void GetScriptableObjects()
    {
        foreach (LootTableBase loadedData in lootTableBases)
        {
            if (loadedData.toolTypes.Count != 0)
            {
                foreach (int i in loadedData.toolTypes)
                {
                    lootTables[i].Add(loadedData);
                }
            }
            else
            {
                lootTables[0].Add(loadedData);
            }
        }
    }


    public ItemLootTable RollTables(AcceptedTools item)
    {
        if (lootTables[(int)item].Count != 0)
        {
            int totalChance = 0;
            foreach (LootTableBase lootTable in lootTables[(int)item])
            {
                totalChance += lootTable.chance;
            }
            float value = totalChance * UnityEngine.Random.Range(0f, 1f);
            foreach(LootTableBase lootTable in lootTables[(int)item])
            {
                value -= lootTable.chance;
                if(value <= 0)
                {
                    ItemLootTable t = lootTable.RollTable();
                    t.baseDes = lootTable.description;
                    return t;
                }
            }
        }
        else
        {
            Debug.LogWarning("No Loot Tables for the tool type: " + item.ToString());
        }
       
        return new ItemLootTable();
    }

}

