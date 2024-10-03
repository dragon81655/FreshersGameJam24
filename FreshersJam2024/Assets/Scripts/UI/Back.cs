using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back()
    {
        Debug.Log("back");
    }
}
