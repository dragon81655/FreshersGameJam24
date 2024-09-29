using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int i;
    SceneManagerGame game;
    private void Start()
    {
        game = GetComponent<SceneManagerGame>();
        if(game)
        game.ChangeScene(i);   
    }
}
