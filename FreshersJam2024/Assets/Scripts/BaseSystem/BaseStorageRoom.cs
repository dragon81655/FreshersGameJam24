using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStorageRoom : BaseRoom
{
    [SerializeField]
    private Button craftingMenuButton;

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
}
