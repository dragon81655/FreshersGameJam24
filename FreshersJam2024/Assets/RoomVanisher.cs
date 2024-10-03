using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVanisher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Chest chest;
    void Start()
    {
        chest.dissapear();
    }
}
