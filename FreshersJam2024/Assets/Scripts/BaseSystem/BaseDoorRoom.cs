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
        // Call the update from room parent class
        BaseRoomUpdate();

        // Activate door button click possibility for door
        TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        if (doorTileMapCollider != null ) 
        { 
            if (doorTileMapCollider.isActiveAndEnabled)
            {
                if(Input.GetMouseButtonDown(0)) 
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3Int tilePos = doorTileMap.WorldToCell(mouseWorldPos);

                    if (doorTileMap.HasTile(tilePos)) 
                    {
                        OpenDoor();
                    }
                    
                }
                
            }
        }
    }

    protected override void OnRoomEntered()
    {
        // Get door collider for click possibility for door
        TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        // Activate the collider for the door
        if(!doorTileMapCollider.isActiveAndEnabled) 
        {
            doorTileMapCollider.gameObject.SetActive(true);            
        }        
    }

    protected override void OnRoomExited() 
    {
        // Get door collider for click possibility for door
        TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        // Activate the collider for the door
        doorTileMapCollider.gameObject.SetActive(false);
    }

    void OpenDoor()
    {
        Debug.Log("Door Opened. Start Exploration");
    }
}
