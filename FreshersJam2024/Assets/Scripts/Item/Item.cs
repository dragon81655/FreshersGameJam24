using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item : MonoBehaviour
{

    public PseudoItemId itemId;
    public int durability;
    public bool inContainer = false;
    private int life = 3;
    [SerializeField] public Color tintColor;
    [SerializeField] public Color origonalColor;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform.parent.gameObject);
        //tintItem();
    }

    private void Update()
    {
        if (transform.position.y < -100) Destroy(transform.parent.gameObject);

        if(inContainer && GetComponent<Renderer>().material.color == tintColor)
        {
            untintItem(); 
        }else if(!inContainer && GetComponent<Renderer>().material.color == origonalColor)
        {
            tintItem();
        }

    }
    public void LifeCycle()
    {
        if (!inContainer) life--;
        if(life <= 0) Destroy(transform.parent.gameObject);
    }
    public void tintItem()
    {
        GetComponent<Renderer>().material.color = tintColor;
        //Debug.Log("tinted!");
    }

    public void untintItem()
    {
        GetComponent<Renderer>().material.color = origonalColor;
        //Debug.Log("untinted!");
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
