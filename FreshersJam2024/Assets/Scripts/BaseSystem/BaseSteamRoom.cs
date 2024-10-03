using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseSteamRoom : BaseRoom
{
    [SerializeField]
    Tilemap steamTileMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Call the update from room parent class
        BaseRoomUpdate();
    }

    protected override void OnRoomEntered()
    {

    }
}
