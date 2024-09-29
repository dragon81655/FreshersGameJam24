using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] gos;
    public List<GameObject> toControl;
    void Start()
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
            if(go!= null)
            go.SetActive(false);
        }
        foreach(GameObject go in toControl)
        {
            go.SetActive(false);
        }
    }

    public void TurnOn()
    {
        foreach (GameObject go in gos)
        {
            if(go!= null)
            {
                go.SetActive(true);
            }
        }
        foreach (GameObject go in toControl)
        {
            go.SetActive(true);
        }
    }
}
