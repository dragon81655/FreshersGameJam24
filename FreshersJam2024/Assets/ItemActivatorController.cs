using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivatorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject b =GameObject.Find("ItemActivator");
        if (b)
        {
            b.GetComponent<ItemActivator>().TurnOn();
        }
    }
}
