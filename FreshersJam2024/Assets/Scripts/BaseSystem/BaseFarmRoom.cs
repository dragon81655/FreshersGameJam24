using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseFarmRoom : BaseUpgradableRoom
{
    public static BaseFarmRoom instance { get; private set; }

    // Number of potatoes we want to collect every day 
    public int PotatoesPerDayQuantity;

    // Number of potatoes we want to increase every time we upgrade the room
    [SerializeField]
    private int PotatoesUpdateQuantity;

    // Array to hold the potatoes sprites
    public SpriteRenderer[] PotatoesSpriteArray;

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
        HideAllPotatoes();  // Ensure all potatoes are hidden at the start
        ShowRandomPotatoesBasedOnFarmLevel();  // Show potatoes based on current farm level
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

    // Hide all potatoes method
    private void HideAllPotatoes()
    {
        foreach (SpriteRenderer sprite in PotatoesSpriteArray)
        {
            sprite.enabled = false;  // Hide all sprites
        }
    }

    // Method to show random potato sprites based on the farm room level
    private void ShowRandomPotatoesBasedOnFarmLevel()
    {
        int farmLevel = UpgradesStaticClass.farmRoomLvl;
        int potatoesToShow = 0;

        // Determine the number of potatoes to show based on the farm level
        switch (farmLevel)
        {
            case 0:
                potatoesToShow = 3;
                break;
            case 1:
                potatoesToShow = 4;
                break;
            case 2:
                potatoesToShow = 5;
                break;
            case 3:
                potatoesToShow = 7;
                break;
            case 4:
                potatoesToShow = 9;
                break;
            case 5:
                potatoesToShow = 12;
                break;
            default:
                break;
        }

        // Show the random potatoes
        ShowRandomPotatoes(potatoesToShow);
    }

    // Method to show a specific number of random potatoes
    private void ShowRandomPotatoes(int numberOfPotatoes)
    {
        // Ensure all potatoes are hidden first
        HideAllPotatoes();

        // Create a list of all available potatoes' indices
        List<int> availablePotatoes = new List<int>();
        for (int i = 0; i < PotatoesSpriteArray.Length; i++)
        {
            availablePotatoes.Add(i);
        }

        // Randomly pick potatoes to show
        for (int i = 0; i < numberOfPotatoes; i++)
        {
            if (availablePotatoes.Count == 0)
                break;

            // Pick a random index from the available potatoes
            int randomIndex = Random.Range(0, availablePotatoes.Count);
            int potatoIndex = availablePotatoes[randomIndex];

            // Show the selected potato sprite
            PotatoesSpriteArray[potatoIndex].enabled = true;

            // Remove the selected potato from the available list
            availablePotatoes.RemoveAt(randomIndex);
        }
    }
}