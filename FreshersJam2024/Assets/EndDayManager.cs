using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayManager : MonoBehaviour
{
    [SerializeField]
    private Button endDayButton;

    [SerializeField]
    private Transform familyMemberSpawnLocation; // The spawn location for new family members
    [SerializeField]
    private SpriteRenderer newFamilyMemberSprite; // The sprite for the new family member

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

        if (BaseTableRoom.instance.NewFamilyMemberFound)
        {
            // Adding the new family member to the room with sprite and location
            BaseTableRoom.instance.AddFamilyMember(familyMemberSpawnLocation, newFamilyMemberSprite);

            // Optionally reset the flag after processing
            BaseTableRoom.instance.NewFamilyMemberFound = false;
        }
    }
}
