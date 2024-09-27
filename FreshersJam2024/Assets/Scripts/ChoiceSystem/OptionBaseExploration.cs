using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "OptionLootTable")]
public class OptionBaseExploration : ScriptableObject
{
    [Header("Possible options (Blank what is not needed)")]
    [TextArea(3,5)]
    public string text;
    public Options[] options = new Options[4];
}


