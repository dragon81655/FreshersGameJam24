using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class backpack : MonoBehaviour
{
    //Dictionary<PseudoItemId, int> itemList = new Dictionary<PseudoItemId, int>();

    public List<GameObject> prefabs;
    List<GameObject> objects = new List<GameObject>();

    Dictionary<PseudoItemId, List<Item>> itemList = new Dictionary<PseudoItemId, List<Item>>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        foreach (GameObject pref in prefabs)
        {
            GameObject tempG = Instantiate(pref, new Vector3(-3, 0, 0), Quaternion.identity);
            if (tempG)
            {
                Debug.Log("Instantiate success");
                objects.Add(tempG);
            }
            else
            {
                Debug.Log("Instantiate unsuccess");
            }
        }

        foreach(GameObject ob in objects)
        {
            ob.GetComponent<Item>().destroyRigidBody();
        }
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


        //    Debug.Log("got!");
        //    //Debug.Log(
        //    //    other.transform.parent.GetComponent<Item>().itemId + ", " +
        //    //    other.transform.parent.GetComponent<Item>().durability
        //    //    );

            //    collision.GetComponent<Item>().untintItem();

            //    PseudoItemId newitem = collision.GetComponent<Item>().itemId;
            //    int newDurability = collision.GetComponent<Item>().durability;

            //    //PseudoItemId newitem = collision.transform.parent.GetComponent<Item>().itemId;
            //    //int newDurability = collision.transform.parent.GetComponent<Item>().durability;

            //    if (itemList.Count == 0)
            //    {
            //        itemList.Add(newitem, newDurability);

            //        //Debug.Log(newitem + " added as new item with " + newDurability + " durability");
            //    }
            //    else {

            //        if (itemList.ContainsKey(newitem))
            //        {
            //            itemList[newitem] = itemList[newitem] + newDurability;
            //            //Debug.Log( newDurability + " durability added to " + newitem);
            //        }
            //        else
            //        {
            //            itemList.Add(newitem, newDurability);
            //            //Debug.Log(newitem + " added as new item with " + newDurability + " durability");
            //        }
            //    }

            //    Debug.Log(itemList);
            //}
            //else
            //{
            //    Debug.Log("not got");
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


        //    PseudoItemId olditem = collision.GetComponent<Item>().itemId;
        //    int oldDurability = collision.GetComponent<Item>().durability;

                //    if (itemList.ContainsKey(olditem))
                //    {
                //        itemList[olditem] = itemList[olditem] - oldDurability;
                //        //Debug.Log(oldDurability + " durability removed from " + olditem);

                //        if(itemList[olditem] == 0)
                //        {
                //            //Debug.Log(olditem + " was removed");
                //            itemList.Remove(olditem);
                //        }
                //        else if(itemList[olditem] < 0)
                //        {
                //            Debug.LogError("BUG " + olditem + " HAS DURABILIY OF " + itemList[olditem]);
                //            itemList.Remove(olditem);
                //        }
                //    }
                //    else
                //    {
                //        Debug.LogError("BUG " + olditem + "  WAS REMOVED WHIE DIDNT EXIST");
                //    }

                //    Debug.Log(itemList);
        }
    }

    private void OnMouseDrag()
    {

    }

    public Dictionary<PseudoItemId, List<Item>> getItemsInBag()
    {
        return itemList;
    }

    public void addItemsToBag(Dictionary<PseudoItemId, List<Item>> items)
    {

    }

    public void addItemsToBag(List<Item> items)
    {

        //Debug.Log("item hit");

        foreach(Item it in items)
        {
            Instantiate(objects[0], gameObject.transform.position + new Vector3(0, 7, 0), Quaternion.identity);

            foreach (GameObject ob in objects)
            {
                if (ob.GetComponent<Item>() &&
                    ob.GetComponent<Item>().itemId == it.itemId)
                {
                    //Instantiate(ob, gameObject.transform.position + new Vector3(0, 7, 0), Quaternion.identity);

                    Debug.Log("instatteate hit");
                }
                else
                {
                    Debug.Log("inst not hit");
                    //Debug.Log("instatteate no hit - object" + ob.GetComponent<Item>().itemId + ", item to add" + it.itemId);
                }
            }
        }
    }
}
