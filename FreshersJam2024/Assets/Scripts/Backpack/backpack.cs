using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;

public class backpack : MonoBehaviour
{
    Dictionary<PseudoItemId, int> itemList = new Dictionary<PseudoItemId, int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {
            Debug.Log("got!");
            //Debug.Log(
            //    other.transform.parent.GetComponent<Item>().itemId + ", " +
            //    other.transform.parent.GetComponent<Item>().durability
            //    );

            collision.GetComponent<Item>().untintItem();

            PseudoItemId newitem = collision.GetComponent<Item>().itemId;
            int newDurability = collision.GetComponent<Item>().durability;

            //PseudoItemId newitem = collision.transform.parent.GetComponent<Item>().itemId;
            //int newDurability = collision.transform.parent.GetComponent<Item>().durability;

            if (itemList.Count == 0)
            {
                itemList.Add(newitem, newDurability);

                //Debug.Log(newitem + " added as new item with " + newDurability + " durability");
            }
            else {

                if (itemList.ContainsKey(newitem))
                {
                    itemList[newitem] = itemList[newitem] + newDurability;
                    //Debug.Log( newDurability + " durability added to " + newitem);
                }
                else
                {
                    itemList.Add(newitem, newDurability);
                    //Debug.Log(newitem + " added as new item with " + newDurability + " durability");
                }
            }
        }
        else
        {
            Debug.Log("not got");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Item>())
        {

            collision.GetComponent<Item>().tintItem();

            PseudoItemId olditem = collision.GetComponent<Item>().itemId;
            int oldDurability = collision.GetComponent<Item>().durability;

            if (itemList.ContainsKey(olditem))
            {
                itemList[olditem] = itemList[olditem] - oldDurability;
                //Debug.Log(oldDurability + " durability removed from " + olditem);

                if(itemList[olditem] == 0)
                {
                    //Debug.Log(olditem + " was removed");
                    itemList.Remove(olditem);
                }
                else if(itemList[olditem] < 0)
                {
                    Debug.LogError("BUG " + olditem + " HAS DURABILIY OF " + itemList[olditem]);
                    itemList.Remove(olditem);
                }
            }
            else
            {
                Debug.LogError("BUG " + olditem + "  WAS REMOVED WHIE DIDNT EXIST");
            }
        }
    }

    private void OnMouseDrag()
    {

    }

    public Dictionary<PseudoItemId, int> getItemsInBag()
    {
        return itemList;
    }
}
