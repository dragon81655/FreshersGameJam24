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
        foreach (GameObject go in gos)
        {
            if (go != null)
            {
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
            if(go!= null)
            {
                go.GetComponent<Rigidbody2D>().simulated = true;
                go.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }
        GameObject go2 = GameObject.Find("Bag_No_Background_0");
        if (go2 != null)
        {
            go2.GetComponentInChildren<SpriteRenderer>().enabled = true;

        }
    }
}
