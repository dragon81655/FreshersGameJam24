using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivatorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    int a = 0;
    private void Update()
    {
        if(a == 0)
        {
            GameObject b = GameObject.Find("ItemActivator");
            if (b)
            {
                b.GetComponent<ItemActivator>().TurnOn();
            }
            a++;        
        }
    }
}
