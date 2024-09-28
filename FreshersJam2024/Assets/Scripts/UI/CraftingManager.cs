using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

[Serializable]
public struct buttonsToItems
{
    public GameObject button;
    public GameObject item;
}

[Serializable]
public class CraftingManager : MonoBehaviour
{
    public List<buttonsToItems> buttons;

    GameObject backpack;
    List<GameObject> items;
    List<craftingItem> craftingList;

    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.FindGameObjectsWithTag("Backpack")[0];
        craftingList = backpack.GetComponent<backpack>().craftingList;

        foreach(buttonsToItems buttonI in buttons)
        {
            buttonI.button.GetComponent<Button>().onClick.AddListener(() => craftItem(buttonI.item));
        }

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

        foreach(buttonsToItems buttonI in buttons)
        {
            GameObject button = buttonI.button;

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
                            if (anItem.GetComponentInChildren<Item>().itemId == titcw.itemToCraftWith.GetComponentInChildren<Item>().itemId)
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
                button.GetComponent<Button>().interactable = true;
                Debug.Log(item.name + " craftable");
            }
            else
            {
                //button.GetComponent<Button>().SetEnabled(false);
                button.GetComponent<Button>().interactable = false;

                Debug.Log(item.name + " not craftable");
            }
        }
    }

    public void craftItem(GameObject item)
    {
        Debug.Log("craft item hit");
        foreach(craftingItem cItem in craftingList)
        {
            if(cItem.itemToCraft == item)
            {
                Debug.Log("got item");
                foreach (theItemsToCraftWith cItemCW in cItem.itemsToCraftWith)
                {
                    int itemcount = cItemCW.amount;
                    foreach (GameObject it in items)
                    {
                        Debug.Log("item - " + it.name);
                        if (it.GetComponentInChildren<Item>().itemId == cItemCW.itemToCraftWith.GetComponentInChildren<Item>().itemId)
                        {
                            Debug.Log("got item to remove");
                            it.GetComponentInChildren<Item>().reduceDurability();
                            itemcount--;
                        }
                        if (itemcount == 0)
                            break;
                    }
                }
                break;
            }
        }
        List<Item> spawn = new List<Item>();
        spawn.Add(item.GetComponentInChildren<Item>());
        backpack.GetComponent<backpack>().addItemsToBag(spawn);
    }
}
