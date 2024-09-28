using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour
{
    [SerializeField]
    private Button openBackpackButton;

    [SerializeField]
    private Button openChestButton;

    [SerializeField]
    private Button collectResourcesButton;

    // Start is called before the first frame update
    void Start()
    {
        // Assign methods to On Click events for each button
        openBackpackButton.onClick.AddListener(OpenBackpack);
        openChestButton.onClick.AddListener(OpenChest);
        collectResourcesButton.onClick.AddListener(CollectResources);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OpenBackpack()
    {
        // Show the backpack on the screen
    }

    void OpenChest()
    {
        // Show the chest on the screen
    }

    void CollectResources()
    {
        BaseFarmRoom farmRoom = GetComponent<BaseFarmRoom>();

        if (farmRoom != null)
        {
            farmRoom.CollectPotatoes();
        }

    }

    void OpenUpgradeMenu()
    {
        // Open the upgrade menu
    }

    void UpgradeChest()
    {
        // Change chest tile or sprite image
    }

    void UpgradeFarm()
    {
        // Change farm room tiles
        BaseFarmRoom farmRoom = GetComponent<BaseFarmRoom>();

        if (farmRoom != null)
        {
            farmRoom.UpgradeRoom();
        }
    }
}
