using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseStorageRoom : BaseRoom
{
    [SerializeField]
    Tilemap storageTileMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnRoomEntered()
    {
        // Get door collider for click possibility for storage management
        TilemapCollider2D storageTileMapCollider = storageTileMap.GetComponent<TilemapCollider2D>();

        if (CameraManager.instance.HasZoomedIn)
        {
            // Activate the collider for the door
            storageTileMapCollider.gameObject.SetActive(true);
        }
    }
}
