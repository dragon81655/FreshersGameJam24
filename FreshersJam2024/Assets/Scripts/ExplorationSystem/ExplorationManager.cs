using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationManager : MonoBehaviour
{
    private ExplorationEventController eventController;
    private LootTablesController lootTablesController;
    

    private void Start()
    {
        eventController = GetComponent<ExplorationEventController>();
        lootTablesController= GetComponent<LootTablesController>();

    }
    public void StartExploration ()
    {
        eventController.StartExploration();
    }

    public void RollLootTables()
    {
        //Debug.Log("Rolled loot tables");
        ItemLootTable t = lootTablesController.RollTables(AcceptedTools.None);
        Debug.Log(t);
    }
}
