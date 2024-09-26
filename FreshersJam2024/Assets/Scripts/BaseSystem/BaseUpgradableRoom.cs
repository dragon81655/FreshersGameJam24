using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUpgradableRoom : BaseRoom
{
    [SerializeField]
    private SpriteRenderer NewRoomSpriteAfterUpgrade;

    protected int level;

    protected ResourceManager resourcesManager;

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
        BaseRoomSprite = NewRoomSpriteAfterUpgrade;
    }

    void GetUpgradeCost()
    {

    }
}
