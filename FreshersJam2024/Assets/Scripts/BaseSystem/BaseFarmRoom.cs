using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFarmRoom : BaseUpgradableRoom
{
    // Number of bottles of water we currently have
    private int CurrentPotatoesQuantity;

    // Max number of ptatoes we can have (increase after upgrade)
    private int MaxPotatoesQuantity;

    // Number of potatoes we want to increase every time we upgrade the room
    [SerializeField]
    private int UpgradePotatoesQuantity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectPotatoes()
    {

    }

    public override void UpgradeRoom()
    {
        // Call the base class method
        base.UpgradeRoom();

        // Increase max potatoes quantity we can collect
        MaxPotatoesQuantity += UpgradePotatoesQuantity;
    }
}
