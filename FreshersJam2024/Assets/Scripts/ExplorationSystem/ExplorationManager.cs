using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplorationManager : MonoBehaviour
{
    //Fucking hell, this is bad code
    private AcceptedTools?[] acceptedTools;


    private ExplorationEventController eventController;
    private LootTablesController lootTablesController;
    private OptionControllerTables optionController;
    private backpack backpackC;
    [SerializeField] private UnityEvent<ItemLootTable> onLootTableRolled;
    [SerializeField] private UnityEvent onExplorationStarted;

    [SerializeField] private ExplorationLogUIController logs;

    private StoryController storyController;
    

    private void Start()
    {
        acceptedTools = new AcceptedTools?[System.Enum.GetValues(typeof(PseudoItemId)).Length];
        //The piece of code that is as elegant as Gorlock the Destroyer
        acceptedTools[(int)PseudoItemId.Gun] = AcceptedTools.ImprovisedGun;
        acceptedTools[(int)PseudoItemId.Wrench] = AcceptedTools.Wrench;
        acceptedTools[(int)PseudoItemId.Knife] = AcceptedTools.Knife;
        acceptedTools[(int)PseudoItemId.Axe] = AcceptedTools.Axe;
        acceptedTools[(int)PseudoItemId.HeavyKnife] = AcceptedTools.HeavyKnife;

        eventController = GetComponent<ExplorationEventController>();
        lootTablesController= GetComponent<LootTablesController>();
        optionController = FindAnyObjectByType<OptionControllerTables>();
        optionController.gameObject.SetActive(false);
        backpackC = GameObject.Find("BacpackObject")?.GetComponent<backpack>();
        storyController = GetComponent<StoryController>();
        //DontDestroyOnLoad(gameObject);
    }
    public void StartExploration ()
    {
        eventController.StartExploration();
        onExplorationStarted.Invoke();
    }

    public void NextTurn()
    {
        if(!backpackC) backpackC = GameObject.Find("BacpackObject").GetComponent<backpack>();
        List<Item> items = backpackC.getItemsInBag()[PseudoItemId.Potato];
        if (items.Count == 0)
        {
            logs.AddMessage("No more potatos! You can't keep exploring!\n");
            return;
        }
        Item item = items[0];
        if (item.durability > 0)
        {
            item.reduceDurability();
            if(item == null) items.RemoveAt(0);
            eventController.NextTurn();
        } 
    }

    public void QuitExploring(int scene)
    {
        GameObject.Find("SceneManager").GetComponent<SceneManagerGame>().ChangeScene(scene);
        gameObject.SetActive(false);
    }

    public void RollLootTables()
    {
        Debug.Log("Rolled loot tables");
        List<AcceptedTools> tools = new List<AcceptedTools>();
        tools.Add(AcceptedTools.None);
        AcceptedTools tool = AcceptedTools.None;
        if (backpackC) {
            Dictionary<PseudoItemId, List<Item>> itemL = backpackC.getItemsInBag();
            foreach(PseudoItemId p in itemL.Keys)
            {
                if (acceptedTools[(int)p] != null)
                {
                    tools.Add((AcceptedTools)acceptedTools[(int)p]);
                }
            }
        }
        if (tools.Count > 0)
        {
            tool = tools[UnityEngine.Random.Range(0, tools.Count)];
        }
        ItemLootTable t = lootTablesController.RollTables(tool);
        if(t.onRoll != null)
        t.onRoll.Invoke();

        if(backpackC && t.item != null)
        {
            List<Item> items = new List<Item>();
            foreach(ListItemsItem i in t.item)
            {
                Item newItem = new Item();
                newItem.itemId = i.id;
                newItem.durability = i.count;
                items.Add(newItem);
            }
            backpackC.addItemsToBag(items);
            Debug.Log("Added items on loottable: " + items.Count);
        }
        storyController.ProgressStory();
        if (t.hasOptions)
        {
            optionController.gameObject.SetActive(true);
            optionController.LoadOptions(t.options);
        }
        onLootTableRolled.Invoke(t);
    }

    public void OptionChose(Options op)
    {
        ItemLootTable t = op.output.RollTable();
        onLootTableRolled.Invoke(t);
        if (backpackC)
        {
            List<Item> items = new List<Item>();
            foreach (ListItemsItem i in t.item)
            {
                Item newItem = new Item();
                newItem.itemId = i.id;
                newItem.durability = i.count;
                items.Add(newItem);
            }
            backpackC.addItemsToBag(items);
            Debug.Log("Added items on option: " + items.Count);
        }
    }
}
