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
        GameObject.Find("SceneManager").GetComponent<SceneManagerGame>().ChangeScene(2);
        gameObject.SetActive(false);
    }

    //public void QuitExploring(int scene)
    //{
    //    GameObject.Find("SceneManager").GetComponent<SceneManagerGame>().ChangeScene(scene);
    //    gameObject.SetActive(false);
    //}
}
