using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    //void Update()
    //{

    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<Item>())
        {
            collision.GetComponentInChildren<Item>().inContainer = true;
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
        }
    }
}
