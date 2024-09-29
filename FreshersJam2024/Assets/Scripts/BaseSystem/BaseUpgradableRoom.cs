using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseUpgradableRoom : BaseRoom
{
    [SerializeField]
    private TilemapRenderer NewRoomAfterUpgrade;

    protected int level;

    protected ResourceManager resourcesManager;

    [SerializeField]
    List<Item> upgradeItemsNeeded;

    // Cost to upgrade to the next level

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UpgradeRoom()
    {
    }

    void GetUpgradeCost()
    {

    }
}
