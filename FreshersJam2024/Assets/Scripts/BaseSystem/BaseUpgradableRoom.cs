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

    // Cost to upgrade to the next level
    [SerializeField]
    List<ListItemsItem> upgradeItemsNeeded;

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
        if(upgradeItemsNeeded.Count == 0)
        {
            Debug.Log("Upgrade Room");
        }
        else 
        {
            Debug.Log("Materials Still Needed");
        }
    }
}
