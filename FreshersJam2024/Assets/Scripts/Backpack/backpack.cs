using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


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

[Serializable]
public struct theItemsToCraftWithListWrapper
{
    public List<theItemsToCraftWith> itemsToCraftWith;
}

[Serializable]
public struct craftingUpgrade
{
    public upgradeNames name;
    public List<theItemsToCraftWithListWrapper> itemsToCraftWithLevels;
}

public class backpack : MonoBehaviour
{

    public List<GameObject> prefabs;

    Dictionary<PseudoItemId, List<Item>> itemList = new Dictionary<PseudoItemId, List<Item>>();

    public List<craftingItem> craftingList;

    public List<Vector3> backPackUpgradeScales;
    public List<int> backpackUpgradeAmounts;
    public List<craftingUpgrade> craftingUpgradeList;
    public GameObject backpackCraftingItem;
    int backpackAtUpgrade = 0;

    private float factor = 1f;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.toDestroy.Add(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpgradeBackPack(float factor)
    {
        Debug.Log("UpgradeBackPack hit");
        List<GameObject> items = GameObject.FindGameObjectsWithTag("Item").ToList();
        //foreach (List<Item> item in itemList.Values)
        //{
        foreach (GameObject item2 in items)
        {
            Vector3 val = item2.gameObject.transform.localScale;
            val *= factor;
            item2.gameObject.transform.localScale = new Vector3(val.x, val.y, 1);
        }
        this.factor *= factor;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            //collision.GetComponent<Item>().untintItem();
            collision.GetComponent<Item>().inContainer = true;

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

            //collision.GetComponent<Item>().tintItem();
            collision.GetComponent<Item>().inContainer = false;

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

    public GameObject addItemsToBag(List<Item> items)
    {
        GameObject item2 = new GameObject();
        foreach (Item it in items)
        {
            foreach (GameObject pr in prefabs)
            {
                if (pr.GetComponentInChildren<Item>() &&
                    pr.GetComponentInChildren<Item>().itemId == it.itemId)
                {
                    item2 = Instantiate(pr, gameObject.transform.position + new Vector3(0, 7, 1), Quaternion.identity);
                    Vector3 val = item2.gameObject.transform.localScale;
                    val *= factor;
                    item2.gameObject.transform.localScale = new Vector3(val.x, val.y, 1);

                    

                    //Debug.Log("reeee");
                    //Debug.Log("instatteate hit - " + pr.GetComponentInChildren<Item>().itemId);
                }
                else
                {
                    //Debug.Log("inst not hit");
                    //Debug.Log("instatteate no hit - object" + ob.GetComponent<Item>().itemId + ", item to add" + it.itemId);
                }
            }
        }

        return item2;
    }

    public void destroyAllOutsideOfContainer()
    {
        List<GameObject> items = GameObject.FindGameObjectsWithTag("Item").ToList();

        foreach (GameObject item in items)
        {
            if(item.GetComponentInChildren<Item>() && !item.GetComponentInChildren<Item>().inContainer)
            {
                Destroy(item);
            }
        }
    }
}
