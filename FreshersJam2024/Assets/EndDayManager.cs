using System.Collections;
using System.Collections.Generic;
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

    void EndDay()
    {
        // Collect potatoes from the farm room (adds PotatoesPerDayQuantity to the inventory)
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
