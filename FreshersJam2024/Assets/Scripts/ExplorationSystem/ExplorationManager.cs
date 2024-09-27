using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplorationManager : MonoBehaviour
{
    private ExplorationEventController eventController;
    private LootTablesController lootTablesController;
    private OptionControllerTables optionController;
    [SerializeField] private UnityEvent<ItemLootTable> onLootTableRolled;
    [SerializeField] private UnityEvent onExplorationStarted;
    

    private void Start()
    {
        eventController = GetComponent<ExplorationEventController>();
        lootTablesController= GetComponent<LootTablesController>();
        optionController = FindAnyObjectByType<OptionControllerTables>();
        optionController.gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }
    public void StartExploration ()
    {
        eventController.StartExploration();
        onExplorationStarted.Invoke();
    }

    public void RollLootTables()
    {
        Debug.Log("Rolled loot tables");
        //ROLL WEAPON
        //ADD INV
        ItemLootTable t = lootTablesController.RollTables(AcceptedTools.None);
        t.onRoll.Invoke();
        if (t.hasOptions)
        {
            optionController.gameObject.SetActive(true);
            optionController.LoadOptions(t.options);
            eventController.SetPause(true);
        }
        onLootTableRolled.Invoke(t);
    }

    public void OptionChose(Options op)
    {
        //ADD INV
        ItemLootTable t = op.output.RollTable();
        onLootTableRolled.Invoke(t);
        eventController.SetPause(false);
    }
}
