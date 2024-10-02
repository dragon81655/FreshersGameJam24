using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseFarmRoom : BaseUpgradableRoom
{
    public static BaseFarmRoom instance { get; private set; }

    // Number of potatoes we want to collect every day
    [SerializeField]
    public int PotatoesPerDayQuantity;

    // Number of potatoes we want to increase every time we upgrade the room
    [SerializeField]
    private int PotatoesUpdateQuantity;

    

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnRoomEntered()
    {
    }

    public void CollectPotatoes()
    {
        // Add per day potatoes quantity to the inventory
        List<Item> potatoes = new List<Item>();

        for (int i = 0; i < PotatoesPerDayQuantity; i++)
        {
            potatoes.Add(new Item { itemId = PseudoItemId.Potato });
        }

        InventoryStaticClass.AddItems(potatoes);
    }

    public override void UpgradeRoom()
    {
        // Call the base class method
        base.UpgradeRoom();

        // Increase max potatoes quantity we can collect
        PotatoesPerDayQuantity += PotatoesUpdateQuantity;
    }
}
