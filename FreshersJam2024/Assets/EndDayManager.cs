using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayManager : MonoBehaviour
{
    [SerializeField]
    private Button endDayButton;

   private int dayNumber;

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
        dayNumber = 0;  // Initialize day number
        endDayButton.onClick.AddListener(EndDay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndDay()
    {
        // Collect potatoes from the farm room (adds PotatoesPerDayQuantity to the inventory)
        BaseFarmRoom.instance.CollectPotatoes();

        if (dayNumber == 3 || dayNumber == 5 || dayNumber == 7)
        {
            BaseStorageRoom.instance.NewFamilyMemberFound = true;
        }

        // Check for specific days to show family members
        if (BaseStorageRoom.instance.NewFamilyMemberFound)
        {
            if (dayNumber == 3)
            {
                // Show the first family member
                BaseStorageRoom.instance.ShowFamilyMember(0);  // Show the family member at index 0
                BaseStorageRoom.instance.NewFamilyMemberFound = false;  // Reset the flag after processing
            }

            if (dayNumber == 5)
            {
                // Show the second family member
                BaseStorageRoom.instance.ShowFamilyMember(1);  // Show the family member at index 1
                BaseStorageRoom.instance.NewFamilyMemberFound = false;  // Reset the flag after processing
            }

            if (dayNumber == 7)
            {
                // Show the third family member
                BaseStorageRoom.instance.ShowFamilyMember(2);  // Show the family member at index 2
                BaseStorageRoom.instance.NewFamilyMemberFound = false;  // Reset the flag after processing

            }
        }

        dayNumber++;
    }
}
