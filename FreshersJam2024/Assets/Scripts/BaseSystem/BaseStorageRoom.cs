using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStorageRoom : BaseRoom
{
    [SerializeField]
    Sprite BackpackSprite;

    [SerializeField]
    Sprite ChestSprite;

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
        // Activate crafting button click possibility for backpack and chest
    }

    void OpenBackpack()
    {

    }

    void OpenChest()
    {

    }

    void UpgradeChest()
    {

    }
}
