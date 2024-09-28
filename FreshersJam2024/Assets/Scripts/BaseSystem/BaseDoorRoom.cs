using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseDoorRoom : BaseRoom
{
    [SerializeField]
    Tilemap doorTileMap;

    // Start is called before the first frame update
    void Start()
    {
        //openDoorButton.onClick.AddListener(OpenDoor);
    }

    // Update is called once per frame
    void Update()
    {

        // Activate door button click possibility for door
        TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        if (doorTileMapCollider != null ) 
        { 
            if (doorTileMapCollider.isActiveAndEnabled)
            {
                OpenDoor();
            }
        }
    }

    protected override void OnRoomEntered()
    {
        // Get door collider for click possibility for door
        TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        if (CameraManager.instance.HasZoomedIn)
        {
            // Activate the collider for the door
            doorTileMapCollider.gameObject.SetActive(true);
        }
    }

    void OpenDoor()
    {

    }
}
