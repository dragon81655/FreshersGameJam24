using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationEventController : MonoBehaviour
{
    [Header("Exploration stats")]
    public int currentTurn = 0;

    [SerializeField]
    private bool exploring = false;
    public bool wishToStop;
    [Header("Pseudo Variables")]
    [SerializeField]
    private int pseudoPotatos;

    private ExplorationManager manager;

    private void Start()
    {
        manager= GetComponent<ExplorationManager>();
    }

    public void StartExploration()
    {
        //Add UI
        NextTurn();
    }
    private bool KeepExploring()
    {
        if (pseudoPotatos > 0 && !wishToStop) return true;
        return false;
    }
    public void StopExploring()
    {
        //Remove UI
    }
    public void NextTurn()
    {
        if (KeepExploring())
        {
            manager.RollLootTables();
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("Item"))
            {
                Item t = g.GetComponentInChildren<Item>();
                t.LifeCycle();
            }
        }
        else
        {
            StopExploring();
        }
    }
}
