using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<PseudoItemId, List<Item>> inventory = new Dictionary<PseudoItemId, List<Item>>();
    public static Chest instance;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    //void Update()
    //{
    public bool RemoveItem(Item item)
    {
        if (inventory.Keys.Contains(item.itemId))
        {
            bool toReturn = inventory[item.itemId].Remove(item);
            if (toReturn) Destroy(item.transform.parent.gameObject);
            return toReturn;
        }
        return false;
    }

    public bool RemoveItem(PseudoItemId id)
    {
        if (inventory.Keys.Contains(id))
        {
            if (inventory[id].Count > 0)
            {
                Item t = inventory[id][0];
                bool toReturn = inventory[id].Remove(t);
                if (toReturn) Destroy(t.transform.parent.gameObject);
                return toReturn;
            }
        }
        return false;
    }

    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<Item>())
        {
            Item i = collision.GetComponentInChildren<Item>();
            i.inContainer = true;
            if (inventory.Keys.Contains(i.itemId))
            {
                inventory[i.itemId].Add(i);
            }
            else
            {
                inventory[i.itemId] = new List<Item>
                {
                    i
                };
            }

            Debug.Log("chest trigger hit with item");
        }
        else
        {
            Debug.Log("chest trigger hit not item");
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<Item>())
        {
            collision.GetComponentInChildren<Item>().inContainer = false;
            Item i = collision.GetComponentInChildren<Item>();
            i.inContainer = false;
            if (inventory.Keys.Contains(i.itemId))
            {
                inventory[i.itemId].Remove(i);
            }
            else
            {
                inventory[i.itemId] = new List<Item>
                {
                    i
                };
            }

        }
    }

    public void dissapear()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(500, 0, 0);

        foreach(KeyValuePair<PseudoItemId, List<Item>> items in inventory)
        {
            foreach(Item item in items.Value)
            {
                item.transform.parent.position = item.transform.parent.position + new Vector3(500, 0, 0);
            }
        }

    }

    public void appear()
    {
        gameObject.transform.position = gameObject.transform.position - new Vector3(500, 0, 0);

        foreach (KeyValuePair<PseudoItemId, List<Item>> items in inventory)
        {
            foreach (Item item in items.Value)
            {
                item.transform.parent.position = item.transform.parent.position - new Vector3(500, 0, 0);
            }
        }
    }
}
