using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using Unity.VisualScripting;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

[Serializable]
public enum upgradeNames
{
    Backpack = 0,
    farm = 1
}

[Serializable]
public struct buttonsToItems
{
    public GameObject button;
    public GameObject item;
}

[Serializable]
public struct buttonsToUpgrades
{
    public GameObject button;
    public upgradeNames uName;
}

[Serializable]
public class CraftingManager : MonoBehaviour
{
    public List<buttonsToItems> buttons;
    public List<buttonsToUpgrades> upgradeButtons;

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

        foreach(buttonsToUpgrades upgradeButton in upgradeButtons)
        {
            Debug.Log("upg button " + upgradeButton.uName);

            if(upgradeButton.uName == upgradeNames.Backpack)
            {
                Debug.Log("got backpack button");
                upgradeButton.button.GetComponent<Button>().onClick.AddListener(upgradeBackpack);

            }
            else if(upgradeButton.uName == upgradeNames.farm)
            {
                Debug.Log("got farm button");
                upgradeButton.button.GetComponent<Button>().onClick.AddListener(upgradeFarm);
            }
        }

        UpadteItems();
        checkCraftable();
    }

    // Update is called once per frame
    void Update()
    {
        //checkCraftable();

        if (!backpack)
        {
            backpack = GameObject.FindGameObjectsWithTag("Backpack")[0];
            Debug.Log("no backpack");
            //checkCraftable();
        }

        if (craftingList.Count < 2)
        {
            craftingList = backpack.GetComponent<backpack>().craftingList;
            Debug.Log("no backpack craftig list");
            //checkCraftable();
        }
    }

    public void UpadteItems()
    {
        items = GameObject.FindGameObjectsWithTag("Item").ToList();
    }

    void checkCraftable()
    {
        //items = GameObject.FindGameObjectsWithTag("Item").ToList();

        Debug.Log("amount of items - " + items.Count);

        foreach (buttonsToItems buttonI in buttons)
        {
            GameObject button = buttonI.button;

            bool craftable = true;
            //the item to craft
            GameObject item = button.GetComponent<ItemButton>().item;

            //get the items needed
            foreach (craftingItem craftItem in craftingList)
            {
                if (craftItem.itemToCraft == item)
                {
                    //Debug.Log("item to craft - " + craftItem.itemToCraft.name);
                    foreach (theItemsToCraftWith itemToCraftW in craftItem.itemsToCraftWith)
                    {
                        //Debug.Log("item to craft with - " + itemToCraftW.itemToCraftWith.name);
                        int itemAmount = 0;
                        foreach (GameObject anItem in items)
                        {
                            if (anItem.GetComponentInChildren<Item>().itemId == itemToCraftW.itemToCraftWith.GetComponentInChildren<Item>().itemId)
                            {
                                itemAmount++;
                            }
                        }
                        //Debug.Log("amount in level - " + itemAmount);

                        if (itemToCraftW.amount > itemAmount)
                        {
                            craftable = false;
                            //Debug.Log("no crafty");
                        }
                    }
                    break;
                }
            }

            if (craftable)
            {
                button.GetComponent<Button>().interactable = true;
                //Debug.Log(item.name + " craftable");
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
                //Debug.Log(item.name + " not craftable");
            }

            //Canvas.ForceUpdateCanvases();
        }
    }

    //public void checkUpgradesCraftable()
    //{
    //    //items = GameObject.FindGameObjectsWithTag("Item").ToList();

    //    Debug.Log("amount of items - " + items.Count);

    //    foreach (buttonsToItems buttonI in buttons)
    //    {
    //        GameObject button = buttonI.button;

    //        bool craftable = true;
    //        //the item to craft
    //        GameObject item = button.GetComponent<ItemButton>().item;

    //        //get the items needed
    //        foreach (craftingItem craftItem in craftingList)
    //        {
    //            if (craftItem.itemToCraft == item)
    //            {
    //                //Debug.Log("item to craft - " + craftItem.itemToCraft.name);
    //                foreach (theItemsToCraftWith itemToCraftW in craftItem.itemsToCraftWith)
    //                {
    //                    //Debug.Log("item to craft with - " + itemToCraftW.itemToCraftWith.name);
    //                    int itemAmount = 0;
    //                    foreach (GameObject anItem in items)
    //                    {
    //                        if (anItem.GetComponentInChildren<Item>().itemId == itemToCraftW.itemToCraftWith.GetComponentInChildren<Item>().itemId)
    //                        {
    //                            itemAmount++;
    //                        }
    //                    }
    //                    //Debug.Log("amount in level - " + itemAmount);

    //                    if (itemToCraftW.amount > itemAmount)
    //                    {
    //                        craftable = false;
    //                        //Debug.Log("no crafty");
    //                    }
    //                }
    //                break;
    //            }
    //        }

    //        if (craftable)
    //        {
    //            button.GetComponent<Button>().interactable = true;
    //            //Debug.Log(item.name + " craftable");
    //        }
    //        else
    //        {
    //            button.GetComponent<Button>().interactable = false;
    //            //Debug.Log(item.name + " not craftable");
    //        }

    //        //Canvas.ForceUpdateCanvases();
    //    }
    //}

    public void craftItem(GameObject item)
    {
        items = GameObject.FindGameObjectsWithTag("Item").ToList();
        List<GameObject> itemsToRemove = new List<GameObject>();

        //Debug.Log("craft item hit");
        foreach(craftingItem cItem in craftingList)
        {
            if(cItem.itemToCraft == item)
            {
                //Debug.Log("got item");
                foreach (theItemsToCraftWith cItemCW in cItem.itemsToCraftWith)
                {
                    int itemcount = cItemCW.amount;
                    foreach (GameObject it in items)
                    {
                        //Debug.Log("item - " + it.name);
                        if (it.GetComponentInChildren<Item>().itemId == cItemCW.itemToCraftWith.GetComponentInChildren<Item>().itemId)
                        {
                            //Debug.Log("got item to remove");
                            it.GetComponentInChildren<Item>().reduceDurability();
                            itemsToRemove.Add(it);
                            itemcount--;
                        }
                        if (itemcount == 0)
                            break;
                    }
                }

                foreach(GameObject itTD in itemsToRemove)
                {
                    items.Remove(itTD);
                    Debug.Log("removed " + itTD.name);
                }

                break;
            }
        }
        List<Item> spawn = new List<Item>();
        spawn.Add(item.GetComponentInChildren<Item>());
        GameObject newItem = backpack.GetComponent<backpack>().addItemsToBag(spawn);
        if (newItem)
        {
            items.Add(newItem);
        }

        checkCraftable();
    }

    public void upgradeBackpack()
    {
        backpack.GetComponent<backpack>().UpgradeBackPack(0.5f);
        Debug.Log("Upgrade backpack hit");
    }

    public void upgradeFarm()
    {
        Debug.Log("Upgradefarm hit");
    }
}
