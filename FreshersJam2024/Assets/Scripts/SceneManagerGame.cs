using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEvent onExit;

    public static SceneManagerGame instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PauseMenu.toDestroy.Add(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeScene(int i)
    {
        Debug.Log("Before invoke");
        onExit.Invoke();
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
