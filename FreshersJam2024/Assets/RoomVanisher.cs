using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVanisher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool appear;
    void Start()
    {
        
        if(appear) Chest.instance.appear();
        else Chest.instance.dissapear();
    }
}
