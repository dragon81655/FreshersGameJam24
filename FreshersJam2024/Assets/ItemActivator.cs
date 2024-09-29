using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] gos;
    void Awake()
    {
        CheckForNewItems();
        DontDestroyOnLoad(gameObject);
    }
    public void CheckForNewItems()
    {
        gos = GameObject.FindGameObjectsWithTag("Item");
    }
    public void TurnOff()
    {
        Debug.Log("Reaching turn off point!");
        Debug.Log(gos);
        foreach (GameObject go in gos)
        {
            Debug.Log("Try to turn off item");
            if (go != null)
            {
                Debug.Log("Foreach in turn off");
                go.GetComponent<Rigidbody2D>().simulated = false;
                go.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
        GameObject go2 = GameObject.Find("Bag_No_Background_0");
        Debug.Log(go2.name);

        if (go2!= null)
            {
                go2.GetComponentInChildren<SpriteRenderer>().enabled = false;

            }
        
    }

    public void TurnOn()
    {
        Debug.Log(gos.Length);
        CheckForNewItems();
        foreach (GameObject go in gos)
        {
            Debug.Log("Try to turn on item");
            if(go!= null)
            {
                Debug.Log("Check foreach in turnon");
                go.GetComponent<Rigidbody2D>().simulated = true;
                go.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }
        GameObject go2 = GameObject.Find("Bag_No_Background_0");
        Debug.Log(go2.name);
        if (go2 != null)
        {
            go2.GetComponentInChildren<SpriteRenderer>().enabled = true;

        }
    }
}
