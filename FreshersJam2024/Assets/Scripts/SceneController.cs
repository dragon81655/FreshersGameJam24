using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int i;
    SceneManagerGame game;
    [SerializeField] private float timer;
    private void Start()
    {
        game = GetComponent<SceneManagerGame>();
        if(game && timer == 0)
        game.ChangeScene(i);   
    }
    int a = 0;
    private void Update()
    {
        if (a == 0) {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                game.ChangeScene(i);
                a++;
            }
        }
    }


}
