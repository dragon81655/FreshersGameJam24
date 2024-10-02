using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseStorageRoom : BaseUpgradableRoom
{
    [SerializeField]
    Tilemap storageTileMap;

    [SerializeField] private int craftingMenuScene;

    // List or array to hold sprites for each family member
    [SerializeField]
    public SpriteRenderer[] FamilyMemberSpritesArray;  // Set the family sprites in the inspector

    public bool NewFamilyMemberFound;
    public int FamilyMemberCount { get; private set; }  // Track how many family members have been added

    public static BaseStorageRoom instance { get; private set; }

    // Called before Start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        FamilyMemberCount = 0;  // Initialize family member count
        HideAllFamilyMembers();  // Ensure all family members are hidden at the start
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
        GameObject.Find("SceneManager")?.GetComponent<SceneManagerGame>().ChangeScene(craftingMenuScene);

    }

    public override void UpgradeRoom()
    {
        base.UpgradeRoom();

        UpgradesStaticClass.storageRoomLvl++;
    }

    // Method to hide all family members at the beginning
    private void HideAllFamilyMembers()
    {
        foreach (SpriteRenderer sprite in FamilyMemberSpritesArray)
        {
            sprite.enabled = false;  // Hide all sprites
        }
    }

    // Method to show a specific family member sprite based on the index
    public void ShowFamilyMember(int familyMemberIndex)
    {
        // Ensure the index is within bounds of the array
        if (familyMemberIndex >= 0 && familyMemberIndex < FamilyMemberSpritesArray.Length)
        {
            FamilyMemberSpritesArray[familyMemberIndex].enabled = true;  // Show the sprite
            FamilyMemberCount++;  // Increment family member count
        }
    }
}
