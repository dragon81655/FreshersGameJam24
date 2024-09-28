using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class CraftingManager : MonoBehaviour
{
    public List<GameObject> buttons;

    GameObject backpack;
    List<GameObject> items;
    List<craftingItem> craftingList;

    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.FindGameObjectsWithTag("Backpack")[0];
        craftingList = backpack.GetComponent<backpack>().craftingList;

        checkCraftable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkCraftable()
    {
        items = GameObject.FindGameObjectsWithTag("Item").ToList();

        Debug.Log("amount of items - " + items.Count);

        foreach(GameObject button in buttons)
        {
            bool craftable = true;
            //the item to craft
            GameObject item = button.GetComponent<ItemButton>().item;

            //get the items needed
            foreach(craftingItem ci in craftingList)
            {
                if(ci.itemToCraft == item)
                {
                    Debug.Log("item to craft - " + ci.itemToCraft.name);
                    foreach(theItemsToCraftWith titcw in ci.itemsToCraftWith)
                    {
                        Debug.Log("item to craft with - " + titcw.itemToCraftWith.name);
                        int itemAmount = 0;
                        foreach(GameObject anItem in items)
                        {
                            if(anItem == titcw.itemToCraftWith)
                            {
                                itemAmount++;
                            }
                        }
                        Debug.Log("amount in level - " + itemAmount);

                        if(titcw.amount > itemAmount)
                        {
                            craftable = false;
                            Debug.Log("no crafty");
                        }
                    }
                    break;
                }
            }

            if (craftable)
            {
                //button.GetComponent<Button>().SetEnabled(true);
                Debug.Log(item.name + " craftable");
            }
            else
            {
                //button.GetComponent<Button>().SetEnabled(false);
                Debug.Log(item.name + " not craftable");

            }

        }
    }
}
