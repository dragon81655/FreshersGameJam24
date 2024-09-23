using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LootTable")]
public class LootTableBase : ScriptableObject
{
    //Just had this to a list of loot tables based on accepted tools;
    [Header("Basic info")]
    [TextArea(3, 20)]
    public string description;
    public List<AcceptedTools> toolTypes;

    [Header("Loot tables")]
    public List<ItemLootTable> itemLootTables;
}

[Serializable]
public struct ItemLootTable
{
    public List<PseudoItemClass> loot;
    public int chance;
}
public enum AcceptedTools
{
    None = 0,
    Knife = 1,
    Axe = 2
}