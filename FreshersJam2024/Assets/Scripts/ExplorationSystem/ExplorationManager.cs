using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplorationManager : MonoBehaviour
{
    private ExplorationEventController eventController;
    private LootTablesController lootTablesController;
    [SerializeField] private UnityEvent<ItemLootTable> onLootTableRolled;
    [SerializeField] private UnityEvent onExplorationStarted;
    

    private void Start()
    {
        eventController = GetComponent<ExplorationEventController>();
        lootTablesController= GetComponent<LootTablesController>();

    }
    public void StartExploration ()
    {
        eventController.StartExploration();
        onExplorationStarted.Invoke();
    }

    public void RollLootTables()
    {
        Debug.Log("Rolled loot tables");
        ItemLootTable t = lootTablesController.RollTables(AcceptedTools.None);
        onLootTableRolled.Invoke(t);
    }
}
