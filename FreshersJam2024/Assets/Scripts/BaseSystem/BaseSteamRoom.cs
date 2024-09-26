using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSteamRoom : BaseUpgradableRoom
{
    [SerializeField]
    private Sprite WaterSprite;

    [SerializeField]
    private Text WaterQuantityText;

    // Max number of water bottles we can have (increase after upgrade)
    private int MaxWaterQuantity;

    // Number of bottles of water we want to collect every day
    [SerializeField]
    private int WaterBottlesPerDayQuantity;

    // Number of water bottles we want to increase every time we upgrade the room
    [SerializeField]
    private int UpgradeWaterQuantity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectWater()
    {
        base.resourcesManager.waterBottles += MaxWaterQuantity;
    }

    public override void UpgradeRoom()
    {
        // Call the base class method
        base.UpgradeRoom();

        // Increase max water bottles quantity we can collect
        MaxWaterQuantity += UpgradeWaterQuantity;
    }
}
