using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BaseDoorRoom : BaseRoom
{
    [SerializeField]
    Tilemap doorTileMap;

    // List or array to hold sprites for each family member
    public SpriteRenderer[] FamilyMemberSpritesArray;  // Set the family sprites in the inspector

    public bool NewFamilyMemberFound;
    public int FamilyMemberCount { get; private set; }  // Track how many family members have been added

    public static BaseDoorRoom instance { get; private set; }

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
        for (int i = 0; i < StoryProgressionClass.currentStory; i++)
        {
            ShowFamilyMember(i);
        }
        //openDoorButton.onClick.AddListener(OpenDoor);
    }

    // Update is called once per frame
    void Update()
    {
        // Call the update from room parent class
        BaseRoomUpdate();

        // Activate door button click possibility for door
        //TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        /*if (doorTileMapCollider != null ) 
        { 
            if (doorTileMapCollider.gameObject.activeInHierarchy)
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
        }*/
    }

    protected override void OnRoomEntered()
    {
        // Get door collider for click possibility for door
        //TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        // Activate the collider for the door
        //doorTileMapCollider.enabled = true;
    }

    protected override void OnRoomExited() 
    {
        // Get door collider for click possibility for door
        //TilemapCollider2D doorTileMapCollider = doorTileMap.GetComponent<TilemapCollider2D>();

        // Activate the collider for the door
        //doorTileMapCollider.enabled = false;
    }

    void OpenDoor()
    {
        Debug.Log("Door Opened. Start Exploration");
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

        FamilyMemberSpritesArray[familyMemberIndex].enabled = true;  // Show the sprite
    }
}
