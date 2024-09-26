using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    // List with all the rooms of the base
    [SerializeField]
    List<BaseRoom> baseRooms;

    // The resources manager instance
    ResourceManager resourceManager;

    //Manager for the UI of the base
    BaseUIManager baseUIManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initialize the base of the game
    void InitializeBase()
    {

    }

    // Update the base state
    void UpdateBase()
    {

    }

    void UpgradeRoom(BaseUpgradableRoom upgradableRoom)
    {

    }

    // Handle the mouse clicks on the rooms (for zoom in our out, select backpack or chest, etc...)
    void HandleRoomClick(BaseRoom room)
    {

    }
}
