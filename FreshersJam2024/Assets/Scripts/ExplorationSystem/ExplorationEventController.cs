using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationEventController : MonoBehaviour
{
    [Header("Exploration stats")]
    [SerializeField]
    private int minTimeToTriggerEvent;
    [SerializeField]
    private int maxTimeToTriggerEvent;
    //Just set to the time you want
    private float currentTimer = 0;

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
        CalculateNextEvent();
        exploring = true;
    }

    private void CalculateNextEvent()
    {
        currentTimer = UnityEngine.Random.Range(minTimeToTriggerEvent,maxTimeToTriggerEvent);
    }
    private bool KeepExploring()
    {
        if (pseudoPotatos > 0 && !wishToStop) return true;
        return false;
    }

    private void Update()
    {
        if(exploring)
        {
            currentTimer -= Time.deltaTime;
            if(currentTimer <= 0)
            {
                if(KeepExploring())
                {
                    manager.RollLootTables();
                    CalculateNextEvent();
                }
                else
                {
                    exploring= false;
                }
            }
        }
    }
}
