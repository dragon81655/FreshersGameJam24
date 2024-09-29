using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseStorageRoom : BaseUpgradableRoom
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
        // Call the update from room parent class
        BaseRoomUpdate();

        // Activate door button click possibility for door
        TilemapCollider2D storageTileMapCollider = storageTileMap.GetComponent<TilemapCollider2D>();

        if (storageTileMapCollider != null)
        {
            if (storageTileMapCollider.gameObject.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3Int tilePos = storageTileMap.WorldToCell(mouseWorldPos);

                    if (storageTileMap.HasTile(tilePos))
                    {
                        OpenCraftingMenu();
                    }
                }
            }
        }
    }

    protected override void OnRoomEntered()
    {
        // Get door collider for click possibility for storage management
        TilemapCollider2D storageTileMapCollider = storageTileMap.GetComponent<TilemapCollider2D>();

        // Activate the collider for the door
        storageTileMapCollider.gameObject.SetActive(true);
    }

    protected override void OnRoomExited()
    {
        // Get door collider for click possibility for door
        TilemapCollider2D storageTileMapCollider = storageTileMap.GetComponent<TilemapCollider2D>();

        // Activate the collider for the door
        storageTileMap.enabled = false;
    }

    void OpenCraftingMenu()
    {
        Debug.Log("Opening Crafting Meu");
    }

    public override void UpgradeRoom()
    {
        base.UpgradeRoom();

        UpgradesStaticClass.storageRoomLvl++;
    }
}
