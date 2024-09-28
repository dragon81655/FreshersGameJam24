using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

[Serializable]
public struct theItemsToCraftWith
{
    public GameObject itemToCraftWith;
    public int amount;
}
[Serializable]
public struct craftingItem
{
    public GameObject itemToCraft;
    public List<theItemsToCraftWith> itemsToCraftWith;
}

public class backpack : MonoBehaviour
{

    public List<GameObject> prefabs;

    Dictionary<PseudoItemId, List<Item>> itemList = new Dictionary<PseudoItemId, List<Item>>();

    public List<craftingItem> craftingList;

    public List<Vector3> backPackUpgradeScales;
    public List<int> backpackUpgradeAmounts;
    public GameObject backpackCraftingItem;
    int backpackAtUpgrade = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            collision.GetComponent<Item>().untintItem();

            if (itemList.ContainsKey(collision.GetComponent<Item>().itemId))
            {
                itemList[collision.GetComponent<Item>().itemId].Add(collision.GetComponent<Item>());
            }
            else
            {
                itemList.Add(collision.GetComponent<Item>().itemId, new List<Item>());
                itemList[collision.GetComponent<Item>().itemId].Add(collision.GetComponent<Item>());
            }
            //List<Item> test = new List<Item>();
            //test.Add(collision.GetComponent<Item>());
            //addItemsToBag(test);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            
            collision.GetComponent<Item>().tintItem();

            if (itemList.ContainsKey(collision.GetComponent<Item>().itemId) &&
                itemList[collision.GetComponent<Item>().itemId].Contains(collision.GetComponent<Item>())
                )
            {
                itemList[collision.GetComponent<Item>().itemId].Remove(collision.GetComponent<Item>());
            }
            else
            {
                Debug.LogError("BUG " + collision.GetComponent<Item>().itemId + "  WAS REMOVED WHILE DIDNT EXIST");
            }

        }
    }

    private void OnMouseDrag()
    {

    }

    public Dictionary<PseudoItemId, List<Item>> getItemsInBag()
    {
        return itemList;
    }

    public void addItemsToBag(List<Item> items)
    {

        foreach(Item it in items)
        {
            foreach (GameObject pr in prefabs)
            {
                if (pr.GetComponentInChildren<Item>() &&
                    pr.GetComponentInChildren<Item>().itemId == it.itemId)
                {
                    Instantiate(pr, gameObject.transform.position + new Vector3(0, 7, 0), Quaternion.identity);
                    Debug.Log("reeee");
                    //Debug.Log("instatteate hit - " + pr.GetComponentInChildren<Item>().itemId);
                }
                else
                {
                    //Debug.Log("inst not hit");
                    //Debug.Log("instatteate no hit - object" + ob.GetComponent<Item>().itemId + ", item to add" + it.itemId);
                }
            }
        }
    }

    public void upgradeBackpack()
    {

    }
}
