using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{

    public PseudoItemId itemId;
    public int durability;

    [SerializeField] public Color tintColor;
    [SerializeField] public Color origonalColor;

    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject.transform.parent.gameObject);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void tintItem()
    {
        GetComponent<Renderer>().material.color = tintColor;
        Debug.Log("tinted!");
    }

    public void untintItem()
    {
        GetComponent<Renderer>().material.color = origonalColor;
        Debug.Log("untinted!");
    }

    public void reduceDurability()
    {
        Debug.Log("reduceDurability hit");
        durability--;
        if (durability <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);

            Debug.Log("destroy hit");

        }
    }
}
