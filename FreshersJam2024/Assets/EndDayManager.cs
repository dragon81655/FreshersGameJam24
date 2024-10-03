using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndDayManager : MonoBehaviour
{
    [SerializeField]
    private Button endDayButton;

    public static EndDayManager instance { get; private set; }

    // Called before Start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        endDayButton.onClick.AddListener(EndDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CheckWin()
    {
        if(BaseDoorRoom.instance.FamilyMemberCount >= 3)
        {
            SceneManagerGame.instance.ChangeScene(7);
            return;
        }
    }
    private void CheckDeath()
    {
        int amount = 0;
        if (backpack.instance.getItemsInBag().Keys.Contains(PseudoItemId.Potato)) amount += backpack.instance.getItemsInBag()[PseudoItemId.Potato].Count;
        if (Chest.instance.inventory.Keys.Contains(PseudoItemId.Potato)) amount += Chest.instance.inventory[PseudoItemId.Potato].Count;

        if (BaseDoorRoom.instance.FamilyMemberCount+1 > amount)
        {
            
            SceneManagerGame.instance.ChangeScene(5);
            return;
        }
        for (int i = 0; i < BaseDoorRoom.instance.FamilyMemberCount + 1; i++)
        {
            if (Chest.instance.RemoveItem(PseudoItemId.Potato)) continue;
            if (backpack.instance.RemoveItem(PseudoItemId.Potato)) continue;
            Debug.LogError("No items in classes");
            return;
        }
    }

    void EndDay()
    {
        // Collect potatoes from the farm room (adds PotatoesPerDayQuantity to the inventory)
        CheckDeath();
        CheckWin();

        backpack.instance.destroyAllOutsideOfContainer();
        BaseFarmRoom.instance.CollectPotatoes();

        for (int i = 0; i < BaseDoorRoom.instance.FamilyMemberSpritesArray.Length; i++)
        {
            // Check for specific days to show family members
            if (!BaseDoorRoom.instance.NewFamilyMemberFound)
            {
                Debug.Log("No Family Member Found");
                break;
            }
            else
            {
                // Show the first family member
                BaseDoorRoom.instance.ShowFamilyMember(i);  // Show the family member at index 0
                BaseDoorRoom.instance.NewFamilyMemberFound = false;  // Reset the flag after processing
            }
        }
    }
}
