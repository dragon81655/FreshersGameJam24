using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static List<GameObject> toDestroy= new List<GameObject>();
    void Awake()
    {
        toDestroy.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void Resume()
    {
        gameObject.SetActive(false);
    }

    public void MainMeunu()
    {
        DestroyDontDestroyOnLoadScene();
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Item"))
        {
            Destroy(go);
        }
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void DestroyDontDestroyOnLoadScene()
    {
        foreach(GameObject go in toDestroy)
        {
            Destroy(go);
        }
        
    }
}
