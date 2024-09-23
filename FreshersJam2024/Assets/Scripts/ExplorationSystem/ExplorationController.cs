using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Properties;
using UnityEditor;
using UnityEngine;

public class ExplorationController : MonoBehaviour
{
    private List<List<LootTableBase>> lootTables = new List<List<LootTableBase>>(); 
    void Start()
    {
        for (int i = 0;i < Enum.GetValues(typeof(AcceptedTools)).Length; i++)
        {
            lootTables.Add(new List<LootTableBase>());
        }
        GetScriptableObjects(Application.dataPath + "/LootTables/");
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

    private void GetScriptableObjects(string folderPath)
    {
        if (Directory.Exists(folderPath))
        {
            string[] scriptableObjects = Directory.GetFiles(folderPath, "*.asset", SearchOption.AllDirectories);

            foreach (string asset in scriptableObjects)
            {

                string relativePath = "Assets" + asset.Substring(Application.dataPath.Length);
                LootTableBase loadedData = AssetDatabase.LoadAssetAtPath<LootTableBase>(relativePath);

                if (loadedData != null)
                {
                    if(loadedData.toolTypes.Count != 0)
                    {
                        foreach(int i in loadedData.toolTypes)
                        {
                            lootTables[i].Add(loadedData);
                        }
                    }
                    else
                    {
                        lootTables[0].Add(loadedData);
                    }
                }
                else
                {
                    Debug.LogWarning("Failed to load ScriptableObject at path: " + relativePath + " or it isn't a LootTableBase.");
                }
            }
        }
        else
        {
            Debug.LogError("Folder not found.");
        }
    }

}

