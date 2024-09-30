using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayManager : MonoBehaviour
{
    [SerializeField]
    private Button endDayButton;

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
        // Create the list that will hold the items
        List<ListItemsItem> list = new List<ListItemsItem>();

        // Create a single ListItemsItem for potatoes with the total count
        ListItemsItem potatoItem = new ListItemsItem
        {
            id = PseudoItemId.Potato, // Set the id to Potato
            count = BaseFarmRoom.instance.PotatoesPerDayQuantity // Set the total count
        };

        // Add the potato item to the list
        list.Add(potatoItem);

        // Debug to verify the total potatoes added
        Debug.Log("Total Potatoes added to the list: " + potatoItem.count);
    }
}
