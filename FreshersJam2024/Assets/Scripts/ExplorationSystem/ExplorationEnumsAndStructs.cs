using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct ItemLootTable
{
    public List<ListItemsItem> item;
    [TextArea(2, 10)]
    public string addedDesc;
    [HideInInspector]
    public string baseDes;
    public int chance;
    public UnityEvent onRoll;

    [Header("Options")]
    public bool hasOptions;
    public OptionBaseExploration options;
}

[Serializable]
public struct ListItemsItem
{
    public PseudoItemId id;
    public int count;
}

public enum PseudoItemId
{
    Wood = 0,
    ScrapMetal = 1,
    Cloth = 2,
    Knife = 3,
    Axe = 4,
    Wrench = 5,
    GunParts = 6,
    Potato = 7,
    Gun = 8
}
public enum AcceptedTools
{
    None = 0,
    Knife = 1,
    Axe = 2,
    Wrench = 3,
    HeavyKnife = 4,
    ImprovisedGun = 5
}
[Serializable]
public struct Options
{
    public string text;
    public LootTableBase output;
}