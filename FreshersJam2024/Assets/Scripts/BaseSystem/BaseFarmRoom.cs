using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFarmRoom : BaseUpgradableRoom
{

    // Max number of ptatoes we can have (increase after upgrade)
    private int MaxPotatoesQuantity;

    // Number of potatoes we want to collect every day
    [SerializeField]
    private int PotatoesPerDayQuantity;

    // Number of potatoes we want to increase every time we upgrade the room
    [SerializeField]
    private int PotatoesUpdateQuantity;

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
    }

    public void CollectPotatoes()
    {
        base.resourcesManager.potatoes += MaxPotatoesQuantity;
    }

    public override void UpgradeRoom()
    {
        // Call the base class method
        base.UpgradeRoom();

        // Increase max potatoes quantity we can collect
        PotatoesPerDayQuantity += PotatoesUpdateQuantity;
    }
}
