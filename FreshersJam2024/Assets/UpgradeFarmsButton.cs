using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeFarmsButton : MonoBehaviour
{
    public void UpgradeFarm()
    {
        if (UpgradesStaticClass.farmRoomLvl >= 4) return; 
        switch(UpgradesStaticClass.farmRoomLvl)
        {
            case 0:
                if(CheckForMats(PseudoItemId.Wood, 4))
                {
                    ConsumeMats(4, 0);
                }
                break;
            case 1:
                if (CheckForMats(PseudoItemId.Wood, 10))
                {
                    ConsumeMats(10, 0);
                }
                break;
            
            case 2:
                if (CheckForMats(PseudoItemId.Wood, 15) && CheckForMats(PseudoItemId.ScrapMetal, 5))
                {
                    ConsumeMats(15, 5);
                }
                break;
            case 3:
                if (CheckForMats(PseudoItemId.Wood, 20) && CheckForMats(PseudoItemId.ScrapMetal, 10))
                {
                    ConsumeMats(20, 10);
                }
                break;
        }
    }

    private bool CheckForMats(PseudoItemId id,int needed)
    {
        int amount = 0;
        if (backpack.instance.getItemsInBag().Keys.Contains(id)) amount += backpack.instance.getItemsInBag()[id].Count;
        if (Chest.instance.inventory.Keys.Contains(id)) amount += Chest.instance.inventory[id].Count;
        if (amount >= needed) return true;
        return false;
    }
    private void ConsumeMats(int wood, int scrap)
    {
        for (int i = 0; i < wood; i++)
        {
            if (Chest.instance.RemoveItem(PseudoItemId.Wood)) continue;
            if (backpack.instance.RemoveItem(PseudoItemId.Wood)) continue;
            Debug.LogError("No wood");
            return;
        }
        for (int i = 0; i < scrap; i++)
        {
            if (Chest.instance.RemoveItem(PseudoItemId.ScrapMetal)) continue;
            if (backpack.instance.RemoveItem(PseudoItemId.ScrapMetal)) continue;
            Debug.LogError("No Scrap");
            return;
        }
        UpgradesStaticClass.farmRoomLvl++;
    }
}
