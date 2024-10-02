using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Profiling.Memory.Experimental;

//using Unity.VisualScripting;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using static UnityEditor.Progress;
//using UnityEngine.UIElements;
using Unity.VisualScripting;

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
    List<craftingUpgrade> craftingUpgradeList;
    Dictionary<upgradeNames, int> currentUpgradeLevel = new Dictionary<upgradeNames, int>();

    // Start is called before the first frame update
    void Start()
    {
        backpack = GameObject.FindGameObjectsWithTag("Backpack")[0];
        craftingList = backpack.GetComponent<backpack>().craftingList;
        craftingUpgradeList = backpack.GetComponent<backpack>().craftingUpgradeList;


        foreach (buttonsToItems buttonI in buttons)
        {
            buttonI.button.GetComponent<Button>().onClick.AddListener(() => craftItem(buttonI.item));
        }

        foreach(buttonsToUpgrades upgradeButton in upgradeButtons)
        {
            Debug.Log("upg button " + upgradeButton.uName);

            upgradeButton.button.GetComponent<Button>().onClick.AddListener(() => craftUprade(upgradeButton.uName));
            currentUpgradeLevel.Add(upgradeButton.uName, 0);
        }

        UpadteItems();
        checkCraftable();
        checkUpgradesCraftable();
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

        if(craftingUpgradeList.Count < 1)
        {
            craftingUpgradeList = backpack.GetComponent<backpack>().craftingUpgradeList;
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

    public void checkUpgradesCraftable()
    {
        //items = GameObject.FindGameObjectsWithTag("Item").ToList();

        Debug.Log("amount of items - " + items.Count);

        foreach (buttonsToUpgrades buttonI in upgradeButtons)
        {
            Debug.Log("up button " + buttonI.button.name);
            GameObject button = buttonI.button;

            bool craftable = true;
            //the item to craft
            upgradeNames item = button.GetComponent<ItemButton>().name;
            //get the items needed

            foreach (craftingUpgrade craftItem in craftingUpgradeList)
            {
                if (craftItem.name == item)
                {
                    foreach(theItemsToCraftWith itemsCW in craftItem.itemsToCraftWithLevels[currentUpgradeLevel[item]].itemsToCraftWith){
                        int itemAmount = 0;
                        foreach (GameObject anItem in items)
                        {
                            if (anItem.GetComponentInChildren<Item>().itemId == itemsCW.itemToCraftWith.GetComponentInChildren<Item>().itemId)
                            {
                                itemAmount++;
                            }
                        }
                        //Debug.Log("amount in level - " + itemAmount);

                        if (itemsCW.amount > itemAmount)
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
                Debug.Log(buttonI.uName + " craftable");
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
                Debug.Log(buttonI.uName + " not craftable");
            }

            //Canvas.ForceUpdateCanvases();
        }
    }

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

    public void craftUprade(upgradeNames name)
    {
        items = GameObject.FindGameObjectsWithTag("Item").ToList();
        List<GameObject> itemsToRemove = new List<GameObject>();

        //Debug.Log("craft item hit");
        foreach (craftingUpgrade cItem in craftingUpgradeList)
        {
            if (cItem.name == name)
            {
                //Debug.Log("got item");
                foreach (theItemsToCraftWith cItemCW in cItem.itemsToCraftWithLevels[currentUpgradeLevel[name]].itemsToCraftWith)
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

                foreach (GameObject itTD in itemsToRemove)
                {
                    items.Remove(itTD);
                    Debug.Log("removed " + itTD.name);
                }

                break;
            }
        }

        switch (name)
        {
            case upgradeNames.Backpack:
                upgradeBackpack();
                break;
            case upgradeNames.farm:
                upgradeFarm(); 
                break;
        }

        currentUpgradeLevel[name]++;
        Debug.Log("upgraded " + name + " to " + currentUpgradeLevel[name]);

        //List<Item> spawn = new List<Item>();
        //spawn.Add(item.GetComponentInChildren<Item>());
        //GameObject newItem = backpack.GetComponent<backpack>().addItemsToBag(spawn);
        //if (newItem)
        //{
        //    items.Add(newItem);
        //}

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
