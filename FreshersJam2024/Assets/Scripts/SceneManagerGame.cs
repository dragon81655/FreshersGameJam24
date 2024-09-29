using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.toDestroy.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public static void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
