using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int i;
    private void Start()
    {
        SceneManagerGame.ChangeScene(i);   
    }
}
